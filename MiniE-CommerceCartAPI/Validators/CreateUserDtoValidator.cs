using FluentValidation;
using MiniE_CommerceCartAPI.DTOs;

namespace MiniE_CommerceCartAPI.Validators
{
    public class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username can't be empty")
                .MinimumLength(3).WithMessage("Username must contain min. 3 symbol")
                .MaximumLength(15).WithMessage("Username must contain max. 15 symbol")
                ;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Username can't be empty")
                .Must(x=>x.Contains("@")).WithMessage("Email must contain @ symbol")
                .MinimumLength(7).WithMessage("Email must contain min. 7 symbol")
                .MaximumLength(20).WithMessage("Email must contain max. 20 symbol")
                ;
        }
    }
}
