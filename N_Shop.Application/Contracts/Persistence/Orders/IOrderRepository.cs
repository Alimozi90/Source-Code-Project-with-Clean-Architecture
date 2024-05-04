using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Orders;

namespace N_Shop.Application.Contracts.Persistence.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task ChangeOrderSum(Order order);
        Task<Order> GetOrderActiveByUserId(int userId);
        Task<List<Order>> GetOrdersByUserId(int userId);
        Task<Order> GetOrderWithDetails(int orderId, int userId);
    }
}
