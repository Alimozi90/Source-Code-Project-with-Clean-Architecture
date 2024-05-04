using N_Shop.Domain.Common;
using N_Shop.Domain.Users;

namespace N_Shop.Domain.Role_Permissions
{
    public class Role : BaseDomainEntity
    {
        public string Name { get; set; }

        //#region Relations
        //public ICollection<RolePermission> RolePermissions { get; set; }
        //public ICollection<User> Users { get; }
        //#endregion
    }
}
