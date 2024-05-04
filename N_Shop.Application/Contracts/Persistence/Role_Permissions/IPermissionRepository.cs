using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Contracts.Persistence.Role_Permissions
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<bool> ExistPermissionName(string name);
    }
}
