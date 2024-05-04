using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Users;

namespace N_Shop.Persistence.Configurations.Users
{
    public class WalletTypeConfiguration : IEntityTypeConfiguration<WalletType>
    {
        public void Configure(EntityTypeBuilder<WalletType> builder)
        {
        }
    }
}
