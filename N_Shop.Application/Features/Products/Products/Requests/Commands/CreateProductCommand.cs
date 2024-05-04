using MediatR;
using N_Shop.Application.DTOs.Products.Product;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Products.Products.Requests.Commands
{
    public class CreateProductCommand:IRequest<BaseCommandResponse>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
