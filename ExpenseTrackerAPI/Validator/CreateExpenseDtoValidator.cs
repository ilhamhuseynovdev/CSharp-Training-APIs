using ExpenseTrackerAPI.DTOs;
using FluentValidation;

namespace ExpenseTrackerAPI.Validator
{
    public class CreateExpenseDtoValidator:AbstractValidator<CreateExpenseDto>
    {
        public CreateExpenseDtoValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty().WithMessage("Can't be empty")
                .MaximumLength(50).WithMessage("can't be more than 50")
                ;
            RuleFor(x=>x.Date)
                .NotEmpty().WithMessage("Can't be empty")
                ;
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Can't be empty")
                .LessThanOrEqualTo(0).WithMessage("can't be less than 0")
                ;
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Can't be empty")
                .LessThanOrEqualTo(0).WithMessage("can't be less than 0")
                ;

        }
    }
}
