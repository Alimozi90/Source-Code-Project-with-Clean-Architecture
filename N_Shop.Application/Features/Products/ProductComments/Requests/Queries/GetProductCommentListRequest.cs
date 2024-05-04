using MediatR;
using N_Shop.Application.DTOs.Products.ProductComment;

namespace N_Shop.Application.Features.Products.ProductComments.Requests.Queries
{
    public class GetProductCommentListRequest : IRequest<List<ProductCommentListDto>>
    {
        public int ProductId { get; set; }
        public int? ParentId { get; set; }
    }
}
