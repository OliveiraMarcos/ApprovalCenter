using ApprovalCenter.Domain.Category.Commands;
using FluentValidation;
using System;

namespace ApprovalCenter.Domain.Category.Validations
{
    public class CategoryValidation<T> : AbstractValidator<T> where T: CategoryCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 100).WithMessage("The Description must have between 2 and 100 characters");
        }
        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 500).WithMessage("The Description must have between 2 and 500 characters");
        }
    }
}
