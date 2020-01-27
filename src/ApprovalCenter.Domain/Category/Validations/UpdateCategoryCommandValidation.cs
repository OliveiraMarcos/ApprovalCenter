using ApprovalCenter.Domain.Category.Commands;

namespace ApprovalCenter.Domain.Category.Validations
{
    public class UpdateCategoryCommandValidation:CategoryValidation<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
        }
    }
}
