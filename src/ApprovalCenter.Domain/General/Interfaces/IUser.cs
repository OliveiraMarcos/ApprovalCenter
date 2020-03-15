using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ApprovalCenter.Domain.General.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        bool IsAuthenticated();
        string GetUserEmail();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
