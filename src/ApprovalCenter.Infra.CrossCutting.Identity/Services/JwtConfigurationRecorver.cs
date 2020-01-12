using Microsoft.Extensions.Configuration;
using ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt;
using ApprovalCenter.Infra.CrossCutting.Identity.Extensions;
using ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Services
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
