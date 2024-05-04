using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.DTOs.Products.Category;
using N_Shop.Application.Features.Products.Categories.Requests.Queries;

namespace N_Shop.Application.Features.Products.Categories.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryListRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
