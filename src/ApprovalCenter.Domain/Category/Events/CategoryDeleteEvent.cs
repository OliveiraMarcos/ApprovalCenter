using System;

namespace ApprovalCenter.Domain.Category.Events
{
    public class CategoryDeleteEvent:CategoryEvent
    {
        public CategoryDeleteEvent(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }
    }
}
