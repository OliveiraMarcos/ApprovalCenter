using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Category.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Application.Interfaces.Services
{
    public interface ICategoryAppService : IBaseAppService<CategoryDTO, CategoryEntity>
    {
    }
}
