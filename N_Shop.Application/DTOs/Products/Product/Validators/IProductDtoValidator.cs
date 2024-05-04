using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public IProductDtoValidator(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 50)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");


            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .Length(2, 250)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");


            RuleFor(p => p.Pictures)
                .Must(p => p.EndsWith(".png") || p.EndsWith(".jpg"))
                .WithMessage("{PropertyName} Only jpg and png extensions are acceptable");

            RuleFor(p => p.Tags)
                .Length(2, 50)
                .WithMessage("{PropertyName} It is between {MinLength} and {MaxLength}.");


            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be GreaterThan {ComparisonValue}.")
                .LessThan(100000000)
                .WithMessage("{PropertyName} must be LessThan {ComparisonValue}.");


            RuleFor(p => p.Stock)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .LessThan(1000)
                .WithMessage("{PropertyName} must be LessThan {ComparisonValue}.");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                 {
                     var category = await _categoryRepository.Exist(id);
                     return category;
                 })
                .WithMessage("{PropertyName} does not exist.");


            RuleFor(pc => pc.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    if (id == null || id == 0)
                        return true;
                    var user = await _userRepository.Exist(id.Value);
                    return user;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
