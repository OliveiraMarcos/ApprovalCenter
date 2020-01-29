using ApprovalCenter.Domain.Category.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApprovalCenter.Domain.Category.EventHandlers
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryInsertEvent>,
        INotificationHandler<CategoryUpdateEvent>,
        INotificationHandler<CategoryDeleteEvent>
    {
        public Task Handle(CategoryUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CategoryInsertEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CategoryDeleteEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
