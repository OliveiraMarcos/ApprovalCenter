using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Category.Commands;
using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Domain.Category.Interfaces;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using AutoMapper;
using System;

namespace ApprovalCenter.Application.Services
{
    public class CategoryAppService : BaseAppService<CategoryDTO, CategoryEntity>, ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryAppService(IMapper mapper,
                                  ICategoryRepository categoryRepository, 
                                  IMediatorHandler bus, 
                                  IEventStoreRepository eventStoreRepository) : base(mapper, categoryRepository, bus, eventStoreRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override void Delete(Guid id)
        {
            var deleteCategory = new DeleteCategoryCommand(id);
            Bus.SendCommand(deleteCategory);
        }

        public override void Insert(CategoryDTO dto)
        {
            Insert<InsertNewCategoryCommand>(dto);
        }

        public override void Update(CategoryDTO dto)
        {
            Update<UpdateCategoryCommand>(dto);
        }
    }
}
