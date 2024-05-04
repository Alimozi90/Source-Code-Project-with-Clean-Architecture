using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;

namespace N_Shop.Application.DTOs.Products.Category.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new ICategoryDtoValidator(_categoryRepository));
        }
    }
}
