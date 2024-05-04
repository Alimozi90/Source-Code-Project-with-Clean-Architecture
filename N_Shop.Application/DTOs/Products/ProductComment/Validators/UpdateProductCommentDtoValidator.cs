using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductComment.Validators
{
    public class UpdateProductCommentDtoValidator : AbstractValidator<UpdateProductCommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCommentRepository _productCommentRepository;

        public UpdateProductCommentDtoValidator(IUserRepository userRepository, IProductRepository productRepository, IProductCommentRepository productCommentRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _productCommentRepository = productCommentRepository;

            Include(new IProductCommentDtoValidator(_userRepository, _productRepository));

            RuleFor(pc => pc.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var productComment = await _productCommentRepository.Exist(id);
                    return productComment;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
