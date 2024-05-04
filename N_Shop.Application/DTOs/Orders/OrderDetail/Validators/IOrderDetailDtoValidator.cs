using FluentValidation;

namespace N_Shop.Application.DTOs.Orders.OrderDetail.Validators
{
    public class IOrderDetailDtoValidator : AbstractValidator<IOrderDetailDto>
    {
        public IOrderDetailDtoValidator()
        {
            RuleFor(p => p.Count)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .GreaterThan(-1)
                .WithMessage("{PropertyName} must be GreaterThan {ComparisonValue}.")
                .LessThan(100000)
                .WithMessage("{PropertyName} must be LessThan {ComparisonValue}.");
        }
    }
}
