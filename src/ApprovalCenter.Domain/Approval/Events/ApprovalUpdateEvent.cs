using System;

namespace ApprovalCenter.Domain.Approval.Events
{
    public class ApprovalUpdateEvent : ApprovalEvent
    {
        public ApprovalUpdateEvent(Guid id, string subject
                                        , string description
                                        , bool? isApproval
                                        , string justification
                                        , Guid categoryId
                                        , string emailApproval
                                        , DateTime dateCreate
                                        , DateTime? dateApproval
                                        , DateTime? dateRead)
        {
            this.Subject = subject;
            this.Description = description;
            this.IsApproval = isApproval;
            this.Justification = justification;
            this.CategoryId = categoryId;
            this.EmailApproval = emailApproval;
            this.DateCreate = dateCreate;
            this.DateApproval = dateApproval;
            this.DateRead = dateRead;
            Id = id;
            AggregateId = id;
        }
    }
}
