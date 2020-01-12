using AprovationCenter.Infra.CrossCutting.Identity.Authorization.Jwt;

namespace AprovationCenter.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface IJwt
    {
        TokenConfigurations GetConfigurations(string name);
    }
}
