using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Repository;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Application.Services
{
    public class CategoryAppService : BaseAppService<CategoryDTO, CategoryEntity>, ICategoryAppService
    {
        public CategoryAppService(IMapper mapper, 
                                  IRepositoryBase<CategoryEntity> baseRepository, 
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
