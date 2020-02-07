using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Category.Commands;
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

            CreateMap<CategoryDTO, InsertNewCategoryCommand>().ConstructUsing(e => new InsertNewCategoryCommand(e.Name, e.Description));
            CreateMap<CategoryDTO, UpdateCategoryCommand>().ConstructUsing(e => new UpdateCategoryCommand(e.Id,
                                                                                                          e.Name,
                                                                                                          e.Description,
                                                                                                          e.DateCreate));
            CreateMap<CategoryDTO, DeleteCategoryCommand>().ConstructUsing(e => new DeleteCategoryCommand(e.Id));
        }
    }
}
