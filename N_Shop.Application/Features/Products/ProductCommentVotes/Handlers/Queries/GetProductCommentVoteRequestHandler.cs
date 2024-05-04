using MediatR;
using N_Shop.Application.DTOs.Products.ProductCommentVote;
using N_Shop.Application.Features.Products.ProductCommentVotes.Requests.Queries;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Exceptions;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Features.Products.ProductCommentVotes.Handlers.Queries
{
    public class GetProductCommentVoteRequestHandler : IRequestHandler<GetProductCommentVoteRequest, ProductCommentVoteDto>
    {
        private readonly IProductCommentVoteRepository _productCommentVoteRepository;
        public GetProductCommentVoteRequestHandler(IProductCommentVoteRepository productCommentVoteRepository)
        {
            _productCommentVoteRepository = productCommentVoteRepository;
        }
        public async Task<ProductCommentVoteDto> Handle(GetProductCommentVoteRequest request, CancellationToken cancellationToken)
        {
            var productCommentVoteliked = await _productCommentVoteRepository.GetLikedProductCommentVote(request.Id);
            var productCommentVotedisliked = await _productCommentVoteRepository.GetDisLikedProductCommentVote(request.Id);
            return new ProductCommentVoteDto()
            {
                Liked = productCommentVoteliked,
                DisLiked = productCommentVotedisliked
            };
        }
    }
}
