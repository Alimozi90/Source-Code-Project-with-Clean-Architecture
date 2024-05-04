using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Products
{
    public class ProductVoteRepository : GenericRepository<ProductVote>, IProductVoteRepository
    {
        private readonly N_ShopDbContext _context;
        public ProductVoteRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetLikedProductVote(int productId)
        {
            return await _context.ProductVotes.Where(pv => pv.ProductId == productId && pv.Vote).CountAsync();
        }
        public async Task<int> GetDisLikedProductVote(int productId)
        {
            return await _context.ProductVotes.Where(pv => pv.ProductId == productId && !pv.Vote).CountAsync();
        }

        public async Task<ProductVote> GetProductVote(ProductVote productVote)
        {
            return await _context.ProductVotes.FirstOrDefaultAsync(pv => pv.ProductId == productVote.ProductId && pv.UserId == productVote.UserId);
        }

        public async Task ChangeVoteProductVote(ProductVote productVote, bool vote)
        {
            productVote.Vote = vote;
            _context.Entry(productVote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
