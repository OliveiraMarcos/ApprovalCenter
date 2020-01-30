using ApprovalCenter.Domain.Approval.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApprovalCenter.Domain.Approval.EventHandler
{
    public class ApprovalEventHandler :
        INotificationHandler<ApprovalInsertEvent>,
        INotificationHandler<ApprovalUpdateEvent>,
        INotificationHandler<ApprovalDeleteEvent>
    {
        public Task Handle(ApprovalUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ApprovalDeleteEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ApprovalInsertEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
