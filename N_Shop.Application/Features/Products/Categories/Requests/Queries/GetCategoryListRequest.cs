using MediatR;
using N_Shop.Application.DTOs.Products.Category;

namespace N_Shop.Application.Features.Products.Categories.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDto>>
    {

    }
}
