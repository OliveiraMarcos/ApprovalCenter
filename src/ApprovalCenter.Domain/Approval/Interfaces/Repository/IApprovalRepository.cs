using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Core.Interfaces.Repository;

namespace ApprovalCenter.Domain.Approval.Interfaces.Repository
{
    public interface IApprovalRepository : IRepositoryBase<ApprovalEntity>
    {
    }
}
