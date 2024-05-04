using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Contracts.Persistence.Products
{
    public interface IProductCommentRepository : IGenericRepository<ProductComment>
    {
        Task<List<ProductComment>> GetProductCommentsWithDetails(int productId);
        Task<List<ProductComment>> GetProductCommentChildsWithDetails(int productId, int parentId);
        Task ChangeAcceptStatus(ProductComment productComment, bool? AcceptStatus);
    }
}
