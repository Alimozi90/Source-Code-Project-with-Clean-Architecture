using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.DTOs.Products.Category.Validators;
using N_Shop.Application.Features.Products.Categories.Requests.Commands;
using N_Shop.Application.Responses;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Features.Products.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateCategoryDtoValidator(_categoryRepository);

            var validatorResult = await validator.ValidateAsync(request.CreateCategoryDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Create Category Failed.";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Category>(request.CreateCategoryDto);
                category = await _categoryRepository.Add(category);
                response.Success = true;
                response.Message = "Create Category Successful.";
                response.Id = category.Id;
            }
            return response;

        }
    }
}
