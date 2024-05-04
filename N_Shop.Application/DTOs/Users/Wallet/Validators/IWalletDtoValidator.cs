using FluentValidation;

namespace N_Shop.Application.DTOs.Users.Wallet.Validators
{
    public class IWalletDtoValidator : AbstractValidator<IWalletDto>
    {
        public IWalletDtoValidator()
        {

            RuleFor(p => p.Amount)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be GreaterThan {ComparisonValue}.")
                .LessThan(100000000)
                .WithMessage("{PropertyName} must be LessThan {ComparisonValue}.");


            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 250)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");


            RuleFor(p => p.IsPay)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

        }
    }
}
