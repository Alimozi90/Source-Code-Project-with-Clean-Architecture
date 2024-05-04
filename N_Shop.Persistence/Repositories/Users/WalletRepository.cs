using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Domain.Users;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Users
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly N_ShopDbContext _context;
        public WalletRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Wallet>> GetWalletWithDetails(int userId)
        {
            return await _context.Wallets
               .Include(w => w.WalletType)
               .Include(w => w.User)
               .Where(w => w.UserId == userId)
               .ToListAsync();
        }
    }
}
