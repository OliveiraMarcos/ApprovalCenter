using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Domain.Core.Models;
using System;

namespace ApprovalCenter.Domain.Approval.Entities
{
    public class ApprovalEntity : Entity
    {
        protected ApprovalEntity()
        {

        }

        public ApprovalEntity(Guid id
                            , Guid categoryId
                            , string subject
                            , string description
                            , string emailApproval
                            , DateTime dateCreate)
        {
            this.Id = id;
            this.Subject = subject;
            this.Description = description;
            this.CategoryId = categoryId;
            this.EmailApproval = emailApproval;
            this.DateCreate = dateCreate;
        }

        public ApprovalEntity SetJustification(string justification)
        {
            this.Justification = justification;
            return this;
        }
        public ApprovalEntity SetDateApproval(DateTime? dateApproval)
        {
            this.DateApproval = dateApproval;
            return this;
        }
        public ApprovalEntity SetDateRead(DateTime? dateRead)
        {
            this.DateRead = dateRead;
            return this;
        }
        public ApprovalEntity SetIsApproval(bool? isApproval)
        {
            this.IsApproval = isApproval;
            return this;
        }
        public string Subject { get; protected set; }
        public string Description { get; protected set; }
        public bool? IsApproval { get; protected set; }
        public string Justification { get; protected set; }
        public CategoryEntity Category { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public string EmailApproval { get; protected set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime? DateApproval { get; protected set; }
        public DateTime? DateRead { get; protected set; }
    }
}
