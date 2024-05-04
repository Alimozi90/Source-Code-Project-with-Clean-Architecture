using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Users;

namespace N_Shop.Persistence.Configurations.Users
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            //builder.HasOne(w => w.User).WithMany(w => w.Wallets).HasForeignKey(w => w.UserId);

            //builder.HasOne(w => w.WalletType).WithMany(w => w.Wallets).HasForeignKey(w => w.WalletTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
