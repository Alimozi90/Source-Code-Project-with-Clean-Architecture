using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductComment.Validators
{
    public class CreateProductCommentDtoValidator : AbstractValidator<CreateProductCommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCommentRepository _productCommentRepository;

        public CreateProductCommentDtoValidator(IUserRepository userRepository, IProductRepository productRepository, IProductCommentRepository productCommentRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _productCommentRepository = productCommentRepository;

            Include(new IProductCommentDtoValidator(_userRepository,_productRepository));

            RuleFor(pc => pc.ParentId)
             .MustAsync(async (id, token) =>
             {
                 if (id == null || id == 0)
                     return true;
                 var product = await _productCommentRepository.Exist(id.Value);
                 return product;
             })
             .WithMessage("{PropertyName} does not exist.");
        }
    }
}
