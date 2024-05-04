using MediatR;
using N_Shop.Application.DTOs.Products.Category;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Products.Categories.Requests.Commands
{
    public class CreateCategoryCommand:IRequest<BaseCommandResponse>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
