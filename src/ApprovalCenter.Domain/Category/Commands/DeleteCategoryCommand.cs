using ApprovalCenter.Domain.Category.Validations;
using System;

namespace ApprovalCenter.Domain.Category.Commands
{
    public class DeleteCategoryCommand : CategoryCommand
    {
        public DeleteCategoryCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteCategoryCommandValidadion().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
