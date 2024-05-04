using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductComment.Validators
{
    public class IProductCommentDtoValidator : AbstractValidator<IProductCommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public IProductCommentDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;

            RuleFor(pc => pc.Comment)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 100)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");

            RuleFor(pc => pc.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var user = await _userRepository.Exist(id);
                    return user;
                })
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(pc => pc.ProductId)
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
