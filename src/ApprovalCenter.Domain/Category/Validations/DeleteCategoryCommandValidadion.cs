using ApprovalCenter.Domain.Category.Commands;

namespace ApprovalCenter.Domain.Category.Validations
{
    public class DeleteCategoryCommandValidadion : CategoryValidation<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidadion()
        {
            ValidateId();
        }
    }
}
