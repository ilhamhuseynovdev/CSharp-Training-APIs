using BankQueueAPI.DTOs;
using FluentValidation;

namespace BankQueueAPI.Validators
{
    public class CreateServiceDtoValidator:AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Cant be empty")
                .MaximumLength(20).WithMessage("Cant be more than 20")
                ;

            RuleFor(x=>x.Prefix)
                .NotEmpty().WithMessage("Cant be empty")
                .MaximumLength(5).WithMessage("Cant be more than 5")
                ;

        }
    }
}
