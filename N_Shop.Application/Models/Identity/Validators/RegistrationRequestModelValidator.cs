using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.Models.Identity.Validators
{
    public class RegistrationRequestModelValidator : AbstractValidator<RegistrationRequestModel>
    {
        private readonly IUserRepository _userRepository;
        public RegistrationRequestModelValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Include(new IIdentityModelValidator(_userRepository));

            RuleFor(p => p.UserName)
                .MustAsync(async (id, token) =>
                {
                    var userName = await _userRepository.ExistUserName(id);
                    return !userName;
                })
                .WithMessage("{PropertyName} Is Exist.");


            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 100)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.")
                .EmailAddress()
                .WithMessage("{PropertyName} Should be emailAddress.")
                .MustAsync(async (id, token) =>
                {
                    var userName = await _userRepository.ExistEmail(id);
                    return !userName;
                })
                .WithMessage("{PropertyName} Is Exist.");
        }
    }
}
