using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Category.Entities;
using AutoMapper;

namespace ApprovalCenter.Application.AutoMapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDTO>().ReverseMap()
                                                    .ConstructUsing(e => new CategoryEntity(e.Id,
                                                                                            e.Name,
                                                                                            e.Description,
                                                                                            e.DateCreate,
                                                                                            e.DateEdit));
        }
    }
}
