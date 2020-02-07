using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Authorization
{
    public class ClaimsRequirementHandler : AuthorizationHandler<ClaimRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       ClaimRequirement requirement)
        {

            var claim = context.User.Claims.Where(c => c.Type == requirement.ClaimName);
            if (claim != null && claim.Any(c => c.Value.Contains(requirement.ClaimValue)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
