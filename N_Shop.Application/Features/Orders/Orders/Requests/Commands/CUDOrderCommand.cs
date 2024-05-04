using MediatR;
using N_Shop.Application.DTOs.Orders.OrderDetail;

namespace N_Shop.Application.Features.Orders.Orders.Requests.Commands
{
    public class CUDOrderCommand : IRequest<Unit>
    {
        public CUDOrderDetailDto CUDOrderDetailDto { get; set; }
    }
}
