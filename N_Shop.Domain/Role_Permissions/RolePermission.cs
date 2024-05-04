
namespace N_Shop.Domain.Role_Permissions
{
    public class RolePermission
    {
        #region Relations
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }
        #endregion
    }
}
