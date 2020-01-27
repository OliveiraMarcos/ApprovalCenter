using ApprovalCenter.Domain.Approval.Commands;

namespace ApprovalCenter.Domain.Approval.Validations
{
    public class UpdateApprovalCommandValidation : ApprovalValidation<UpdateApprovalCommand>
    {
        public UpdateApprovalCommandValidation()
        {
            ValidateId();
            ValidateEmailApproval();
            ValidateSubject();
            ValidateDescription();
        }
    }
}
