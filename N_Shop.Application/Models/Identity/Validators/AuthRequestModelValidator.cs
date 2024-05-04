using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.Models.Identity.Validators
{
    public class AuthRequestModelValidator : AbstractValidator<AuthRequestModel>
    {
        private readonly IUserRepository _userRepository;
        public AuthRequestModelValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Include(new IIdentityModelValidator(_userRepository));

            //RuleFor(p => p.UserName)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var userName = await _userRepository.ExistUserName(id);
            //        return userName;
            //    })
            //    .WithMessage("{PropertyName} does not exist.");
        }
    }
}
