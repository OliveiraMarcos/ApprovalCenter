using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        private static SigningConfigurations _signing;
        public SigningConfigurations Signing { get { if(_signing == null) _signing = new SigningConfigurations(); return _signing; } }

        public class SigningConfigurations
        {
            public SecurityKey Key { get; }
            public SigningCredentials Credentials { get; }

            public SigningConfigurations()
            {
                using (var provider = new RSACryptoServiceProvider(2048))
                {
                    Key = new RsaSecurityKey(provider.ExportParameters(true));
                }

                Credentials = new SigningCredentials(
                    Key, SecurityAlgorithms.RsaSha256Signature);
            }
        }
    }
}
