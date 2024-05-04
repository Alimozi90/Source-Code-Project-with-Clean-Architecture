using MediatR;
using N_Shop.Application.DTOs.Products.ProductComment;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Products.ProductComments.Requests.Commands
{
    public class UpdateProductCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateProductCommentDto UpdateProductCommentDto { get; set; }
        public ChangeProductCommentAcceptDto? ChangeProductCommentAcceptDto { get; set; }
    }
}
