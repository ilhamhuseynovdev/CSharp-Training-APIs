using ExpenseTrackerAPI.DTOs;
using FluentValidation;
namespace ExpenseTrackerAPI.Validator
{
    public class UpdateCategoryDtoValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Can't be empty")
                .MaximumLength(20).WithMessage("Can't be more than 20")
                .MinimumLength(1).WithMessage("Can't be less than 1")
                ;
        }
    }
}
