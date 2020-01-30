using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Approval.Entities;

namespace ApprovalCenter.Application.Interfaces.Services
{
    public interface IApprovalAppService : IBaseAppService<ApprovalDTO, ApprovalEntity>
    {
    }
}
