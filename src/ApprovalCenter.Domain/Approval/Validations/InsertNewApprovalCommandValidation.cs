using ApprovalCenter.Domain.Approval.Commands;
using ApprovalCenter.Domain.General.Interfaces;

namespace ApprovalCenter.Domain.Approval.Validations
{
    public class InsertNewApprovalCommandValidation : ApprovalValidation<InsertNewApprovalCommand>
    {
        public InsertNewApprovalCommandValidation()
        {
            ValidateEmailApproval();
            ValidateSubject();
            ValidateDescription();
        }
        public class Factory
        {
            public static InsertNewApprovalCommandValidation New(string email)
            {
                var instance = new InsertNewApprovalCommandValidation() { 
                        
                };
                instance.ValidateEmailApproval(email);
                return instance;
            }
        }

    }
    
}
