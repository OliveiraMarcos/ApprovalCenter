using System.Collections.Generic;
using System.Security.Claims;

namespace ApprovalCenter.Domain.General.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
