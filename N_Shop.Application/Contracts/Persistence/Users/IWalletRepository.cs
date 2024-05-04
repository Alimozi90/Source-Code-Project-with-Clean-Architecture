using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Users;

namespace N_Shop.Application.Contracts.Persistence.Users
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        Task<List<Wallet>> GetWalletWithDetails(int userId);
    }
}
