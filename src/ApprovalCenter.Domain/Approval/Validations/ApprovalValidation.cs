using ApprovalCenter.Domain.Approval.Commands;
using FluentValidation;
using System;

namespace ApprovalCenter.Domain.Approval.Validations
{
    public abstract class ApprovalValidation<T> : AbstractValidator<T> where T : ApprovalCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateSubject()
        {
            RuleFor(c => c.Subject)
                .NotEmpty().WithMessage("Please ensure you have entered the Subject")
                .Length(2, 300).WithMessage("The Subject must have between 2 and 300 characters");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 500).WithMessage("The Description must have between 2 and 500 characters");
        }

        protected void ValidateEmailApproval()
        {
            RuleFor(c => c.EmailApproval)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 250).WithMessage("The EmailApproval must have between 2 and 250 EmailApproval");
        }

        protected void ValidateEmailApproval(string email)
        {
            RuleFor(c => c.EmailApproval)
                .NotEqual(email).WithMessage("Do you not permission for run this operation!");
        }
    }
}
