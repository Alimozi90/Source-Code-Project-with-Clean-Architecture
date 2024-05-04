using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductVote.Validators
{
    public class IProductVoteDtoValidator : AbstractValidator<IProductVoteDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public IProductVoteDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;

            RuleFor(pv => pv.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var user = await _userRepository.Exist(id);
                    return user;
                })
                .WithMessage("{PropertyName} does not exist.");


            RuleFor(pv => pv.ProductId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var product = await _productRepository.Exist(id);
                    return product;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
