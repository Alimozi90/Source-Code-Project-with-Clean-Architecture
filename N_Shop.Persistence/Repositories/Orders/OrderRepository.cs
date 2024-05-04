using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Orders;
using N_Shop.Domain.Orders;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly N_ShopDbContext _context;
        public OrderRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeOrderSum(Order order)
        {
            order.OrderSum = order.OrderDetails.Sum(o => o.Price);
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderActiveByUserId(int userId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => !o.IsFinally && o.UserId == userId);
        }

        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await _context.Orders.Include(o => o.User).Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Order> GetOrderWithDetails(int orderId, int userId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);
            if (order != null)
                await _context.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
            return order;
        }


    }
}
