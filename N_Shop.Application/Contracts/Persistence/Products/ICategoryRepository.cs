using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Contracts.Persistence.Products
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> ExistCategoryName(string name);
    }
}
