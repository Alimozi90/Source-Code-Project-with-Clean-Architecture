using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Products
{
    public class ProductCommentVoteRepository : GenericRepository<ProductCommentVote>, IProductCommentVoteRepository
    {
        private readonly N_ShopDbContext _context;
        public ProductCommentVoteRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetLikedProductCommentVote(int productCommentId)
        {
            return await _context.ProductCommentVote.Where(pvc => pvc.ProductCommentId == productCommentId && pvc.Vote).CountAsync();
        }
        public async Task<int> GetDisLikedProductCommentVote(int productCommentId)
        {
            return await _context.ProductCommentVote.Where(pvc => pvc.ProductCommentId == productCommentId && !pvc.Vote).CountAsync();
        }

        public async Task<ProductCommentVote> GetProductCommentVote(ProductCommentVote productCommentVote)
        {
            return await _context.ProductCommentVote.FirstOrDefaultAsync(pvc => pvc.ProductCommentId == productCommentVote.ProductCommentId && pvc.UserId == productCommentVote.UserId);
        }

        public async Task ChangeVoteProductCommentVote(ProductCommentVote productCommentVote, bool vote)
        {
            productCommentVote.Vote = vote;
            _context.Entry(productCommentVote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
