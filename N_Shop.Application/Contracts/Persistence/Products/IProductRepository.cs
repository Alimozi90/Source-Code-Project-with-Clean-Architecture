using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Contracts.Persistence.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithDetails();
        Task<Product> GetProductWithDetails(int id);
    }
}
