using ApprovalCenter.Domain.Category.Commands;

namespace ApprovalCenter.Domain.Category.Validations
{
    public class InsertNewCategoryCommandValidation:CategoryValidation<InsertNewCategoryCommand>
    {
        public InsertNewCategoryCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
        }
    }
}
