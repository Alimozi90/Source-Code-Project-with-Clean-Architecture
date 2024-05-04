using MediatR;
using N_Shop.Application.DTOs.Products.Product;

namespace N_Shop.Application.Features.Products.Products.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
