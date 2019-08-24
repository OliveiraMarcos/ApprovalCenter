using Thundera.Infra.CrossCutting.Identity.Authorization.Jwt;

namespace Thundera.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface IJwt
    {
        TokenConfigurations GetConfigurations(string name);
    }
}
