using MediatR;

namespace N_Shop.Application.Features.Products.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
