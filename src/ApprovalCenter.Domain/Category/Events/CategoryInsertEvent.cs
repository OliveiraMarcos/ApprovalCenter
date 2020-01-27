using System;

namespace ApprovalCenter.Domain.Category.Events
{
    public class CategoryInsertEvent: CategoryEvent
    {
        public CategoryInsertEvent(Guid id, 
            string name, 
            string description, 
            DateTime dateCreate, 
            DateTime dateEdit)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.AggregateId = id;
            this.DateCreate = dateCreate;
            this.DateEdit = dateEdit;
        }
    }
}
