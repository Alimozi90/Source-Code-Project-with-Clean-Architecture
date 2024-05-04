using N_Shop.Domain.Common;

namespace N_Shop.Domain.Role_Permissions
{
    public class Permission : BaseDomainEntity
    {
        public string Name { get; set; }

        //#region Relations
        //public ICollection<RolePermission> RolePermissions { get; set; }
        //#endregion
    }
}
