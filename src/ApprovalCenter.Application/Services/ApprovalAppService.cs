using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Repository;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Application.Services
{
    public class ApprovalAppService : BaseAppService<ApprovalDTO, ApprovalEntity>, IApprovalAppService
    {
        public ApprovalAppService(IMapper mapper, 
                                  IRepositoryBase<ApprovalEntity> baseRepository, 
                                  IMediatorHandler bus, 
                                  IEventStoreRepository eventStoreRepository) : base(mapper, baseRepository, bus, eventStoreRepository)
        {
        }

        public override void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
