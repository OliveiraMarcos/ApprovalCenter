using ApprovalCenter.Domain.Approval.Commands;

namespace ApprovalCenter.Domain.Approval.Validations
{
    public class DeleteApprovalCommandValidation : ApprovalValidation<DeleteApprovalCommand>
    {
        public DeleteApprovalCommandValidation()
        {
            ValidateId();
        }
    }
}
