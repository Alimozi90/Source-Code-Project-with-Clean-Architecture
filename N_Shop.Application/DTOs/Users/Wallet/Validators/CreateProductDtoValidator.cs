using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Users.Wallet.Validators
{
    public class CreateWalletDtoValidator : AbstractValidator<CreateWalletDto>
    {
        private readonly IUserRepository _userRepository;
        public CreateWalletDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Include(new IWalletDtoValidator());

            RuleFor(pc => pc.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var user = await _userRepository.Exist(id);
                    return user;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
