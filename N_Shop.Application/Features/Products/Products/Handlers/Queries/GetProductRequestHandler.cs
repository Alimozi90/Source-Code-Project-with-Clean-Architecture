using MediatR;
using AutoMapper;
using N_Shop.Application.Features.Products.Products.Requests.Queries;
using N_Shop.Application.DTOs.Products.Product;
using N_Shop.Application.Contracts.Persistence.Products;

namespace N_Shop.Application.Features.Products.Products.Handlers.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductRequestHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductWithDetails(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
