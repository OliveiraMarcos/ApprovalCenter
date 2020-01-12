using Microsoft.Extensions.Configuration;
using AprovationCenter.Infra.CrossCutting.Identity.Authorization.Jwt;
using AprovationCenter.Infra.CrossCutting.Identity.Extensions;
using AprovationCenter.Infra.CrossCutting.Identity.Interfaces.Services;

namespace AprovationCenter.Infra.CrossCutting.Identity.Services
{
    public class JwtConfigurationRecorver : IJwt
    {
        private readonly IConfiguration _configuration;
        public JwtConfigurationRecorver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenConfigurations GetConfigurations(string name)
        {
            return _configuration.GetTokenConfigurations(name);
        }
    }
}
