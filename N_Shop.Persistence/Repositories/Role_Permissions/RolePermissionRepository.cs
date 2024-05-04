using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Domain.Role_Permissions;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Role_Permissions
{
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly N_ShopDbContext _context;
        public RolePermissionRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheackPermission(int roleId, int permissionId)
        {
            return await _context.RolePermissions.AnyAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }

        public async Task<List<RolePermission>> GetPermissionsByRoleId(int roleId)
        {
            return await _context.RolePermissions.Where(x => x.RoleId == roleId).ToListAsync();
        }
    }
}
