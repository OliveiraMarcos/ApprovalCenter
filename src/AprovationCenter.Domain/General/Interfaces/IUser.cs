using System.Collections.Generic;
using System.Security.Claims;

namespace AprovationCenter.Domain.General.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
