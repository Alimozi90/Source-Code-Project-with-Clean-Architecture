using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly N_ShopDbContext _context;
        public ProductRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsWithDetails()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetProductWithDetails(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                await _context.Entry(product).Reference(c => c.Category).LoadAsync();

                await _context.Entry(product).Reference(u => u.User).Query().Include(r => r.Role).LoadAsync();
            }
            return product;
        }
    }
}
