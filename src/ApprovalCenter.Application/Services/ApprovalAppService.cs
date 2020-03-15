using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Approval.Commands;
using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Approval.Interfaces.Repository;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using AutoMapper;
using System;

namespace ApprovalCenter.Application.Services
{
    public class ApprovalAppService : BaseAppService<ApprovalDTO, ApprovalEntity>, IApprovalAppService
    {
        private readonly IApprovalRepository _approvalRepository;
        public ApprovalAppService(IMapper mapper,
                                  IApprovalRepository approvalRepository, 
                                  IMediatorHandler bus, 
                                  IEventStoreRepository eventStoreRepository) : base(mapper, approvalRepository, bus, eventStoreRepository)
        {
            _approvalRepository = approvalRepository;
        }

        public override void Delete(Guid id)
        {
            var deleteApproval = new DeleteApprovalCommand(id);
            Bus.SendCommand(deleteApproval);
        }

        public override void Insert(ApprovalDTO dto)
        {
            Insert<InsertNewApprovalCommand>(dto);
        }

        public override void Update(ApprovalDTO dto)
        {
            Update<UpdateApprovalCommand>(dto);
        }
    }
}
