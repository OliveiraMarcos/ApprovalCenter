using ApprovalCenter.Domain.Approval.Validations;
using System;

namespace ApprovalCenter.Domain.Approval.Commands
{
    public class InsertNewApprovalCommand : ApprovalCommand
    {
        public InsertNewApprovalCommand(string subject
                                        , string description
                                        , Guid categoryId
                                        , string emailApproval)
        {
            this.Subject = subject;
            this.Description = description;
            this.CategoryId = categoryId;
            this.EmailApproval = emailApproval;
        }
        public override bool IsValid()
        {
            ValidationResult = new InsertNewApprovalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
