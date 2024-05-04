using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.Models.Identity.Validators
{
    public class IIdentityModelValidator : AbstractValidator<IIdentityModel>
    {
        private readonly IUserRepository _userRepository;
        public IIdentityModelValidator(IUserRepository userRepository)
        {

            _userRepository = userRepository;

            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 50)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 50)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");
        }
    }
}
