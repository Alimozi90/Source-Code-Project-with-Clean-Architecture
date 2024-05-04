using MediatR;
using N_Shop.Application.DTOs.Products.ProductComment;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Products.ProductComments.Requests.Commands
{
    public class CreateProductCommentCommand:IRequest<BaseCommandResponse>
    {
        public CreateProductCommentDto CreateProductCommentDto { get; set; }
    }
}
