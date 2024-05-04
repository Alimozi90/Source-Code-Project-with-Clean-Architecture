using MediatR;
using N_Shop.Application.DTOs.Products.ProductVote;

namespace N_Shop.Application.Features.Products.ProductVotes.Requests.Queries
{
    public class GetProductVoteRequest:IRequest<ProductVoteDto>
    {
        public int Id { get; set; }
    }
}
