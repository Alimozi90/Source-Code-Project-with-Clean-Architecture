using MediatR;
using N_Shop.Application.DTOs.Products.ProductVote;
using N_Shop.Application.Features.Products.ProductVotes.Requests.Queries;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Exceptions;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Features.Products.ProductVotes.Handlers.Queries
{
    public class GetProductVoteRequestHandler : IRequestHandler<GetProductVoteRequest, ProductVoteDto>
    {
        private readonly IProductVoteRepository _productVoteRepository;
        public GetProductVoteRequestHandler(IProductVoteRepository productVoteDto)
        {
            _productVoteRepository = productVoteDto;
        }
        public async Task<ProductVoteDto> Handle(GetProductVoteRequest request, CancellationToken cancellationToken)
        {
            var productVoteLiked = await _productVoteRepository.GetLikedProductVote(request.Id);
            var productVoteDisLiked = await _productVoteRepository.GetDisLikedProductVote(request.Id);
            return new ProductVoteDto()
            {
                Liked = productVoteLiked,
                DisLiked = productVoteDisLiked
            };
        }
    }
}
