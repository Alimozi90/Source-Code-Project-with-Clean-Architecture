using MediatR;
using AutoMapper;
using N_Shop.Application.Features.Products.Products.Requests.Queries;
using N_Shop.Application.DTOs.Products.Product;
using N_Shop.Application.Contracts.Persistence.Products;

namespace N_Shop.Application.Features.Products.Products.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductListRequestHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<ProductListDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsWithDetails();
            return _mapper.Map<List<ProductListDto>>(products);
        }
    }
}
