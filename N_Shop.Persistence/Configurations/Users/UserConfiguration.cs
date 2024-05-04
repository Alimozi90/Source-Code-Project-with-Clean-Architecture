using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Users;

namespace N_Shop.Persistence.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasOne(u => u.Role).WithMany(u => u.Users).HasForeignKey(u => u.Role).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
