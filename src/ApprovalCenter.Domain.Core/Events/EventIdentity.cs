using System;

namespace ApprovalCenter.Domain.Core.Events
{
    public abstract class EventIdentity : Event
    {
        public Guid Id { get; protected set; }
    }
}
