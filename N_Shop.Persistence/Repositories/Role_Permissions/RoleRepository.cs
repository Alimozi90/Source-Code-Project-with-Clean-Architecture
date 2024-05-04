using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Domain.Role_Permissions;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Role_Permissions
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly N_ShopDbContext _context;
        public RoleRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistRoleName(string name)
        {
            return await _context.Roles.AnyAsync(r => r.Name == name);
        }
    }
}
