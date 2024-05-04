using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Domain.Role_Permissions;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Role_Permissions
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly N_ShopDbContext _context;
        public PermissionRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistPermissionName(string name)
        {
            return await _context.Permissions.AnyAsync(p => p.Name == name);
        }
    }
}
