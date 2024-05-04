using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Contracts.Persistence.Products
{
    public interface IProductCommentVoteRepository : IGenericRepository<ProductCommentVote>
    {
        Task<int> GetLikedProductCommentVote(int productCommentId);
        Task<int> GetDisLikedProductCommentVote(int productCommentId);
        Task<ProductCommentVote> GetProductCommentVote(ProductCommentVote productCommentVote);
        Task ChangeVoteProductCommentVote(ProductCommentVote productCommentVote, bool vote);

    }
}
