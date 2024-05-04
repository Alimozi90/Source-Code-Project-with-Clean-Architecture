using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductVote.Validators
{
    public class CUDProductVoteDtoValidator : AbstractValidator<CUDProductVoteDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public CUDProductVoteDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;

            Include(new IProductVoteDtoValidator(_userRepository, _productRepository));

            RuleFor(pv => pv.Vote)
                .NotNull()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
