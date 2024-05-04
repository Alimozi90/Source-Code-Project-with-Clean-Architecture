using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Orders;
using N_Shop.Domain.Orders;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Orders
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly N_ShopDbContext _context;
        public OrderDetailRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderDetail> GetOrderDetailByOrderIdANDProductId(int orderId, int productId)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }
    }
}
