using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Approval.Interfaces.Repository;
using ApprovalCenter.Infra.Data.Context;

namespace ApprovalCenter.Infra.Data.Repository
{
    public class ApprovalRepository : RepositoryBase<ApprovalEntity>, IApprovalRepository
    {
        public ApprovalRepository(ApprovalCenterContext context) : base(context)
        {
        }
    }
}
