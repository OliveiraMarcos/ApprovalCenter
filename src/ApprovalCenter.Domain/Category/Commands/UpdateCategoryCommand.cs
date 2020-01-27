using ApprovalCenter.Domain.Category.Validations;
using System;

namespace ApprovalCenter.Domain.Category.Commands
{
    public class UpdateCategoryCommand : CategoryCommand
    {
        public UpdateCategoryCommand(Guid id,
            string name,
            string description,
            DateTime dateCreate,
            DateTime dateEdit)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.DateCreate = dateCreate;
            this.DateEdit = dateEdit;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
