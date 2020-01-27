using System;

namespace ApprovalCenter.Domain.Approval.Events
{
    public class ApprovalDeleteEvent : ApprovalEvent
    {
        public ApprovalDeleteEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
