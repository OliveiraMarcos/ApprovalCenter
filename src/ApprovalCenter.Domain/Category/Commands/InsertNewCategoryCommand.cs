using ApprovalCenter.Domain.Category.Validations;
using System;

namespace ApprovalCenter.Domain.Category.Commands
{
    public class InsertNewCategoryCommand : CategoryCommand
    {
        public InsertNewCategoryCommand(
            string name,
            string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public override bool IsValid()
        {
            ValidationResult = new InsertNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
