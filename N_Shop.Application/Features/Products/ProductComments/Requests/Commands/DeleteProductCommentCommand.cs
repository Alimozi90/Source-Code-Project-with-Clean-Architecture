using MediatR;

namespace N_Shop.Application.Features.Products.ProductComments.Requests.Commands
{
    public class DeleteProductCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
