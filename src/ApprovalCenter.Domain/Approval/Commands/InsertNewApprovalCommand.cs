using ApprovalCenter.Domain.Approval.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Domain.Approval.Commands
{
    public class InsertNewApprovalCommand : ApprovalCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new InsertNewApprovalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
