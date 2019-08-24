using Microsoft.Extensions.Configuration;
using Thundera.Infra.CrossCutting.Identity.Authorization.Jwt;
using Thundera.Infra.CrossCutting.Identity.Extensions;
using Thundera.Infra.CrossCutting.Identity.Interfaces.Services;

namespace Thundera.Infra.CrossCutting.Identity.Services
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
