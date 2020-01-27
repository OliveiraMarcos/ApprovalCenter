﻿using Microsoft.Extensions.Configuration;
using ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Extensions
{
    public static class TokenExtensions
    {
        private static TokenConfigurations _tokenConfigurations;
        public static TokenConfigurations GetTokenConfigurations(this IConfiguration configuration, string name)
        {
            if (_tokenConfigurations == null)
            {
                _tokenConfigurations = configuration.GetSection(name).Get<TokenConfigurations>();
            }
            return _tokenConfigurations;
        }
    }
}