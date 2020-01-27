using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Domain.Category.Interfaces;
using ApprovalCenter.Infra.Data.Context;

namespace ApprovalCenter.Infra.Data.Repository
{
    public class CategoryRepository : RepositoryBase<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(ApprovalCenterContext context) : base(context)
        {
        }
    }
}
