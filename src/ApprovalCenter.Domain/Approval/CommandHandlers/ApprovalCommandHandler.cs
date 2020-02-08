using ApprovalCenter.Domain.Approval.Commands;
using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Approval.Events;
using ApprovalCenter.Domain.Approval.Interfaces.Repository;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using ApprovalCenter.Domain.General.CommandHandlers;
using ApprovalCenter.Domain.General.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApprovalCenter.Domain.Approval.CommandHandlers
{
    public class ApprovalCommandHandler : CommandHandler,
        IRequestHandler<InsertNewApprovalCommand, bool>,
        IRequestHandler<UpdateApprovalCommand, bool>,
        IRequestHandler<DeleteApprovalCommand, bool>
    {
        private readonly IMediatorHandler Bus;
        private readonly IApprovalRepository _approvalRepository;
        public ApprovalCommandHandler(IApprovalRepository approvalRepository,
                                      IUnitOfWork uow, 
                                      IMediatorHandler bus, 
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _approvalRepository = approvalRepository;
            Bus = bus;
        }

        public Task<bool> Handle(InsertNewApprovalCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var approval = new ApprovalEntity(Guid.NewGuid()
                                              , request.CategoryId
                                              , request.Subject
                                              , request.Description
                                              , request.EmailApproval
                                              , DateTime.Now);

            _approvalRepository.Add(approval);

            if (Commit())
            {
                Bus.RaiseEvent(new ApprovalInsertEvent(approval.Id
                                              , approval.CategoryId
                                              , approval.Subject
                                              , approval.Description
                                              , approval.EmailApproval
                                              , approval.DateCreate));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateApprovalCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var approval = new ApprovalEntity(request.Id
                                              , request.CategoryId
                                              , request.Subject
                                              , request.Description
                                              , request.EmailApproval
                                              , request.DateCreate)
                .SetIsApproval(request.IsApproval)
                .SetDateApproval(request.DateApproval)
                .SetJustification(request.Justification)
                .SetDateRead(request.DateRead);

            

            _approvalRepository.Attach(approval);

            if (Commit())
            {
                Bus.RaiseEvent(new ApprovalUpdateEvent(approval.Id
                                              , approval.Subject
                                              , approval.Description
                                              , approval.IsApproval
                                              , approval.Justification
                                              , approval.CategoryId
                                              , approval.EmailApproval
                                              , approval.DateCreate
                                              , approval.DateApproval
                                              , approval.DateRead));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(DeleteApprovalCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _approvalRepository.Remove(request.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ApprovalDeleteEvent(request.Id));
            }
            return Task.FromResult(true);
        }
    }
}
