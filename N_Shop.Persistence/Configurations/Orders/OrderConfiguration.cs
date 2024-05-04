using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Orders;

namespace N_Shop.Persistence.Configurations.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.HasOne(o => o.User).WithMany(o => o.Orders).HasForeignKey(o => o.UserId);
        }
    }
}
