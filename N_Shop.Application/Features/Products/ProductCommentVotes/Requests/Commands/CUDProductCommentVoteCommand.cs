using MediatR;
using N_Shop.Application.DTOs.Products.ProductCommentVote;

namespace N_Shop.Application.Features.Products.ProductCommentVotes.Requests.Commands
{
    public class CUDProductCommentVoteCommand : IRequest<Unit>
    {
        public CUDProductCommentVoteDto CUDProductCommentVoteDto { get; set; }
    }
}
