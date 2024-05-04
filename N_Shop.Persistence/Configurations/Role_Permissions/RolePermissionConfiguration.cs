using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Persistence.Configurations.Role_Permissions
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.PermissionId, rp.RoleId });

            //builder.HasOne(rp => rp.Permission).WithMany(rp => rp.RolePermissions).HasForeignKey(rp => rp.PermissionId);

            //builder.HasOne(rp => rp.Role).WithMany(rp => rp.RolePermissions).HasForeignKey(rp => rp.RoleId);

            builder.HasData(new RolePermission()
            {
                RoleId = 1,
                PermissionId = 1,
            },
            new RolePermission()
            {
                RoleId = 1,
                PermissionId = 2,
            });
        }
    }
}
