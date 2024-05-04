using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Products
{
    public class ProductCommentRepository : GenericRepository<ProductComment>, IProductCommentRepository
    {
        private readonly N_ShopDbContext _context;
        public ProductCommentRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeAcceptStatus(ProductComment productComment, bool? AcceptStatus)
        {
            productComment.Accepted = AcceptStatus;
            _context.Entry(productComment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductComment>> GetProductCommentChildsWithDetails(int productId, int parentId)
        {
            return await _context.ProductComments
                   .Include(pc => pc.User)
                   .ThenInclude(pc => pc.Role)
                   .Where(p => p.ProductId == productId && p.ParentId == parentId)
                   .ToListAsync();
        }

        public async Task<List<ProductComment>> GetProductCommentsWithDetails(int productId)
        {
            return await _context.ProductComments
                   .Include(pc => pc.User)
                   .ThenInclude(pc => pc.Role)
                   .Where(p => p.ProductId == productId && p.ParentId == null)
                   .ToListAsync();
        }
    }
}
