using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Persistence.Configurations.Role_Permissions
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(new Permission()
            {
                Id = 1,
                Name = "دسترسی به پنل مدیریت"
            },
            new Permission()
            {
                Id = 2,
                Name = "مدیریت نقش ها"
            });
        }
    }
}
