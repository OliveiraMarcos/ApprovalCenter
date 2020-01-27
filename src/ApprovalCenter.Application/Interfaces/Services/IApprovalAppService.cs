using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Approval.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Application.Interfaces.Services
{
    public interface IApprovalAppService : IBaseAppService<ApprovalDTO, ApprovalEntity>
    {
    }
}
