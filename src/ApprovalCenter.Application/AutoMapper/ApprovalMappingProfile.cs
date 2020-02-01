using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Approval.Entities;
using AutoMapper;

namespace ApprovalCenter.Application.AutoMapper
{
    public class ApprovalMappingProfile : Profile
    {
        public ApprovalMappingProfile()
        {
            CreateMap<ApprovalEntity, ApprovalDTO>().ReverseMap();
        }
    }
}
