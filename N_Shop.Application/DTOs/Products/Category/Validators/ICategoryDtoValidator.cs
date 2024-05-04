using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;

namespace N_Shop.Application.DTOs.Products.Category.Validators
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public ICategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var category = await _categoryRepository.ExistCategoryName(id);
                    return !category;
                })
                .WithMessage("{PropertyName} Is Exist.");
        }
    }
}
