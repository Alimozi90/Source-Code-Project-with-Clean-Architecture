using MediatR;
using N_Shop.Application.DTOs.Products.ProductCommentVote;

namespace N_Shop.Application.Features.Products.ProductCommentVotes.Requests.Queries
{
    public class GetProductCommentVoteRequest:IRequest<ProductCommentVoteDto>
    {
        public int Id { get; set; }
    }
}
