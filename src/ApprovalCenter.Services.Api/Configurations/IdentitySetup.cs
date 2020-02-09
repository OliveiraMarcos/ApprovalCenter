using ApprovalCenter.Infra.CrossCutting.Identity.Authorization;
using ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt;
using ApprovalCenter.Infra.CrossCutting.Identity.Data;
using ApprovalCenter.Infra.CrossCutting.Identity.Extensions;
using ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services;
using ApprovalCenter.Infra.CrossCutting.Identity.Models;
using ApprovalCenter.Infra.CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ApprovalCenter.Services.Api.Configurations
{
    public static class IdentitySetup
    {
        public static void AddIdentitySetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddOptionsSettings(configuration);

            var tokenConf = configuration.GetSection<TokenConfigurations>("Jwt");


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                //var tokenConf = services.BuildServiceProvider().GetService<IJwt>().GetTokenConfigurations();
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = tokenConf.Audience,
                    ValidIssuer = tokenConf.Issuer,
                    IssuerSigningKey = tokenConf.Signing.Key,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        public static void AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteCategoryData", policy => policy.Requirements.Add(new ClaimRequirement("Category", "Write")));
                options.AddPolicy("CanRemoveCategoryData", policy => policy.Requirements.Add(new ClaimRequirement("Category", "Remove")));
                options.AddPolicy("CanReadCategoryData", policy => policy.Requirements.Add(new ClaimRequirement("Category", "Read")));

                options.AddPolicy("CanWriteApprovalData", policy => policy.Requirements.Add(new ClaimRequirement("Approval", "Write")));
                options.AddPolicy("CanRemoveApprovalData", policy => policy.Requirements.Add(new ClaimRequirement("Approval", "Remove")));
                options.AddPolicy("CanReadApprovalData", policy => policy.Requirements.Add(new ClaimRequirement("Approval", "Read")));


                options.AddPolicy("CanWriteValuesData", policy => policy.Requirements.Add(new ClaimRequirement("Values", "Write")));
                options.AddPolicy("CanRemoveValuesData", policy => policy.Requirements.Add(new ClaimRequirement("Values", "Remove")));
                options.AddPolicy("CanReadValuesData", policy => policy.Requirements.Add(new ClaimRequirement("Values", "Read")));
            });
        }
    }
}
