using FluentValidation;
using MiniE_CommerceCartAPI.DTOs;

namespace MiniE_CommerceCartAPI.Validators
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Can't be empty")
                .MaximumLength(20).WithMessage("Can't be more than 20")
                ;
            RuleFor(x=>x.Price)
                 .GreaterThanOrEqualTo(0).WithMessage("Can't be less than 0")
                ;
            RuleFor(x=>x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Can't be less than 0")
                ;
        }
    }
}
