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

        public class Factory
        {
            public static UpdateApprovalCommandValidation New(string email)
            {
                var instance = new UpdateApprovalCommandValidation();
                instance.ValidateEmailApproval(email);
                return instance;
            }
        }
    }
}
