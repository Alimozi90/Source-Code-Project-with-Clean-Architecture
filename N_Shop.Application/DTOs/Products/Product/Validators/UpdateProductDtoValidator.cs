using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.Product.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public UpdateProductDtoValidator(IProductRepository productRepository, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;

            Include(new IProductDtoValidator(_categoryRepository, _userRepository));


            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var prdouct = await _productRepository.Exist(id);
                    return prdouct;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
