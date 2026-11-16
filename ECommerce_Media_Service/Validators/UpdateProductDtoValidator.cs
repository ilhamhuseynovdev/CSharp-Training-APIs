using ECommerce_Media_Service.DTOs;
using FluentValidation;

namespace ECommerce_Media_Service.Validators
{
    public class UpdateProductDtoValidator:AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Can't be empty")
                .MaximumLength(20).WithMessage("Can't be more than 20")
                ;
            RuleFor(x => x.Price)
                 .GreaterThanOrEqualTo(0).WithMessage("Can't be less than 0")
                ;
            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Can't be less than 0")
                ;
        }
    }
}
