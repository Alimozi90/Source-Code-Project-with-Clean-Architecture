using MediatR;
using N_Shop.Application.DTOs.Products.Category;

namespace N_Shop.Application.Features.Products.Categories.Requests.Commands
{
    public class DeleteCategoryCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
