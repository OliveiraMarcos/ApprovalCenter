using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Category.Entities;

namespace ApprovalCenter.Application.Interfaces.Services
{
    public interface ICategoryAppService : IBaseAppService<CategoryDTO, CategoryEntity>
    {
    }
}
