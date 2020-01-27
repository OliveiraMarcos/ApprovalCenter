using ApprovalCenter.Domain.Approval.Validations;
using System;

namespace ApprovalCenter.Domain.Approval.Commands
{
    public class UpdateApprovalCommand : ApprovalCommand
    {
        public UpdateApprovalCommand(string subject
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
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateApprovalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
