using MediatR;
using N_Shop.Application.DTOs.Products.Product;

namespace N_Shop.Application.Features.Products.Products.Requests.Queries
{
    public class GetProductListRequest : IRequest<List<ProductListDto>>
    {

    }
}
