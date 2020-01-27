using ApprovalCenter.Domain.Approval.Validations;
using System;

namespace ApprovalCenter.Domain.Approval.Commands
{
    public class DeleteApprovalCommand : ApprovalCommand
    {
        public DeleteApprovalCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteApprovalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
