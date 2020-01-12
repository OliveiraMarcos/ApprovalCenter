using ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface IJwt
    {
        TokenConfigurations GetConfigurations(string name);
    }
}
