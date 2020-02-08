using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Domain.Approval.Commands;
using ApprovalCenter.Domain.Approval.Entities;
using AutoMapper;

namespace ApprovalCenter.Application.AutoMapper
{
    public class ApprovalMappingProfile : Profile
    {
        public ApprovalMappingProfile()
        {
            CreateMap<ApprovalEntity, ApprovalDTO>()
                .ReverseMap()
                .ConstructUsing(c => new ApprovalEntity(c.Id,
                                                        c.CategoryId,
                                                        c.Subject,
                                                        c.Description,
                                                        c.EmailApproval,
                                                        c.DateCreate));
            CreateMap<ApprovalDTO, InsertNewApprovalCommand>().ConstructUsing(e => new InsertNewApprovalCommand(e.Subject,
                                                                                                                e.Description,
                                                                                                                e.CategoryId,
                                                                                                                e.EmailApproval));

            CreateMap<ApprovalDTO, UpdateApprovalCommand>().ConstructUsing(e => new UpdateApprovalCommand(e.Id, 
                                                                                                            e.Subject,
                                                                                                            e.Description,
                                                                                                            e.IsApproval,
                                                                                                            e.Justification,
                                                                                                            e.CategoryId,
                                                                                                            e.EmailApproval,
                                                                                                            e.DateCreate,
                                                                                                            e.DateApproval,
                                                                                                            e.DateRead));

            CreateMap<ApprovalDTO, DeleteApprovalCommand>().ConstructUsing(e => new DeleteApprovalCommand(e.Id));
        }
    }
}
