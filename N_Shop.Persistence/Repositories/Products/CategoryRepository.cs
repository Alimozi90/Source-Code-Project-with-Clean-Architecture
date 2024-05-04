using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Products
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly N_ShopDbContext _context;
        public CategoryRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ExistCategoryName(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }
    }
}
