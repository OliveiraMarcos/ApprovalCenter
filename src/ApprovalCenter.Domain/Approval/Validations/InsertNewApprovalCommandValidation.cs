using ApprovalCenter.Domain.Approval.Commands;

namespace ApprovalCenter.Domain.Approval.Validations
{
    public class InsertNewApprovalCommandValidation : ApprovalValidation<InsertNewApprovalCommand>
    {
        public InsertNewApprovalCommandValidation()
        {
            ValidateId();
            ValidateEmailApproval();
            ValidateSubject();
            ValidateDescription();
        }
    }
}
