using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.DTOs.Products.Category.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Products.Categories.Requests.Commands;

namespace N_Shop.Application.Features.Products.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryDtoValidator(_categoryRepository);

            var validatorResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);

            category = _mapper.Map(request.UpdateCategoryDto, category);

            await _categoryRepository.Update(category);

            return Unit.Value;
        }
    }
}
