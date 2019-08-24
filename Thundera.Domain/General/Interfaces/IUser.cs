using System.Collections.Generic;
using System.Security.Claims;

namespace Thundera.Domain.General.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
