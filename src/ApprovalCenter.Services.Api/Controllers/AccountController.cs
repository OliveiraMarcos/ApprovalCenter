﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services;
using ApprovalCenter.Infra.CrossCutting.Identity.Models;
using ApprovalCenter.Infra.CrossCutting.Identity.ViewModels.Account;
using System.IdentityModel.Tokens.Jwt;
using ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt;
using Microsoft.Extensions.Options;

namespace ApprovalCenter.Services.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly TokenConfigurations _tokenConfigurations;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory,
            IOptions<TokenConfigurations> options,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _tokenConfigurations = options.Value;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("account")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }


            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                var principal = await _signInManager.CreateUserPrincipalAsync(user);
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                var jwtSecurity = new JwtSecurityTokenHandler();
                var token = jwtSecurity.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(_tokenConfigurations.Seconds),
                    SigningCredentials = _tokenConfigurations.Signing.Credentials,
                    Subject = identity
                });
                _logger.LogInformation(1, "User logged in.");
                return Response(new TokenViewModel(model.Email, jwtSecurity.WriteToken(token), token.ValidTo));
            }

            if (result.IsLockedOut)
            {
                NotifyError(result.ToString(), "User temporarily blocked by invalid attempts");
                return Response(model);
            }

            NotifyError(result.ToString(), "Login failure");
            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                
                // User claim for write customers data
                await _userManager.AddClaimAsync(user, new Claim("Approval", "Read"));
                await _userManager.AddClaimAsync(user, new Claim("Approval", "Write"));

                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }
    }
}
