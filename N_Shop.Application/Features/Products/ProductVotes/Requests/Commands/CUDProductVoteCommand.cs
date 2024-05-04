using MediatR;
using N_Shop.Application.DTOs.Products.ProductVote;

namespace N_Shop.Application.Features.Products.ProductVotes.Requests.Commands
{
    public class CUDProductVoteCommand : IRequest<Unit>
    {
        public CUDProductVoteDto CUDProductVoteDto { get; set; }
    }
}
