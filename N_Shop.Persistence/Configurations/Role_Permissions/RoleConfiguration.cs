using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Persistence.Configurations.Role_Permissions
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role()
                {
                    Id = 1,
                    Name = "ادمین"
                },
                new Role()
                {
                    Id = 2,
                    Name = "کاربر عادی",
                }
                );
        }
    }
}
