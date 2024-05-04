using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;

namespace N_Shop.Application.DTOs.Products.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new ICategoryDtoValidator(_categoryRepository));

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var permission = await _categoryRepository.Exist(id);
                    return permission;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
