using System;

namespace ApprovalCenter.Domain.Approval.Events
{
    public class ApprovalInsertEvent : ApprovalEvent
    {
        public ApprovalInsertEvent(Guid id
                                        , Guid categoryId
                                        , string subject
                                        , string description
                                        , string emailApproval
                                        , DateTime dateCreate)
        {
            this.Subject = subject;
            this.Description = description;
            this.CategoryId = categoryId;
            this.EmailApproval = emailApproval;
            this.DateCreate = dateCreate;
            Id = id;
            AggregateId = id;
        }
    }
}
