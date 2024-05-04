using MediatR;
using N_Shop.Application.DTOs.Orders.Order;

namespace N_Shop.Application.Features.Orders.Orders.Requests.Queries
{
    public class GetOrderListRequest : IRequest<List<OrderDto>>
    {
        public int UserId { get; set; }
        public bool ShowAdmin { get; set; }
    }
}
