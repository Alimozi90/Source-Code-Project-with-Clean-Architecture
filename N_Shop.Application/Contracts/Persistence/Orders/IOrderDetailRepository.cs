using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Orders;

namespace N_Shop.Application.Contracts.Persistence.Orders
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task<OrderDetail> GetOrderDetailByOrderIdANDProductId(int orderId, int productId);
    }
}
