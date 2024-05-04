using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Contracts.Persistence.Products
{
    public interface IProductVoteRepository : IGenericRepository<ProductVote>
    {
        Task<int> GetLikedProductVote(int productId);
        Task<int> GetDisLikedProductVote(int productId);
        Task<ProductVote> GetProductVote(ProductVote productVote);
        Task ChangeVoteProductVote(ProductVote productVote, bool vote);
    }
}
