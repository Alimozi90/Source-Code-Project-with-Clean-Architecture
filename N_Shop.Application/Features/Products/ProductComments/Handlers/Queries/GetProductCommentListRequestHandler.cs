using MediatR;
using AutoMapper;
using N_Shop.Application.Features.Products.ProductComments.Requests.Queries;
using N_Shop.Application.DTOs.Products.ProductComment;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Features.Products.ProductComments.Handlers.Queries
{
    public class GetProductCommentListRequestHandler : IRequestHandler<GetProductCommentListRequest, List<ProductCommentListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductCommentRepository _productCommentRepository;
        public GetProductCommentListRequestHandler(IMapper mapper, IProductCommentRepository productCommentRepository)
        {
            _mapper = mapper;
            _productCommentRepository = productCommentRepository;
        }
        public async Task<List<ProductCommentListDto>> Handle(GetProductCommentListRequest request, CancellationToken cancellationToken)
        {
            List<ProductComment> productComments;
            if (request.ParentId > 0)
            {
                productComments = await _productCommentRepository.GetProductCommentChildsWithDetails(request.ProductId, request.ParentId.Value);
                return _mapper.Map<List<ProductCommentListDto>>(productComments);
            }
            productComments = await _productCommentRepository.GetProductCommentsWithDetails(request.ProductId);
            return _mapper.Map<List<ProductCommentListDto>>(productComments);
        }
    }
}
