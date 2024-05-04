using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Contracts.Persistence.Role_Permissions
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
        Task<List<RolePermission>> GetPermissionsByRoleId(int roleId);
        Task<bool> CheackPermission(int roleId, int permissionId);
    }
}
