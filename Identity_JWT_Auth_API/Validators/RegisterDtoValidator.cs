using FluentValidation;
using Identity_JWT_Auth_API.DTOs;

namespace Identity_JWT_Auth_API.Validators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x=>x.FullName)
                .NotEmpty().WithMessage("Full name can't be empty")
                .MaximumLength(50).WithMessage("Full name can't be more than 50 simvol")
                ;
            RuleFor(x=>x.UserName)
                .NotEmpty().WithMessage("Full name can't be empty")
                .MaximumLength(35).WithMessage("Full name can't be more than 50 simvol")
                ;

            RuleFor(x => x.Email)  // regex should be used here but i don't use it for now because it's simple example for JWT
                .NotEmpty().WithMessage("Email can't be empty")
                .Must(x=>x.Contains("@")).WithMessage("Email must have @ simvol")
                .MinimumLength(12).WithMessage("Email must contain at least 12 simvol")
                ;
            RuleFor(x => x.Password) // you should use regex also for Password
                .NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(8).WithMessage("Password must contain at least 8 simvol")
                .MaximumLength(25).WithMessage("Password must contain at max 25 simvol")
                ;
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password can't be empty")
                .Equal(x => x.Password).WithMessage("Password and Confirm password must be same");
                ;

        }

    }
}
