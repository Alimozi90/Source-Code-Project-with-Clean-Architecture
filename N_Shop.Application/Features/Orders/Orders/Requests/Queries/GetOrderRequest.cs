using MediatR;
using N_Shop.Application.DTOs.Orders.Order;

namespace N_Shop.Application.Features.Orders.Orders.Requests.Queries
{
    public class GetOrderRequest : IRequest<OrderDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool ShowAdmin { get; set; }
    }
}
