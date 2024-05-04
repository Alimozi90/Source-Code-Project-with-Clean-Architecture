using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Orders;

namespace N_Shop.Persistence.Configurations.Orders
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            //builder.HasOne(od => od.Order).WithMany(od => od.OrderDetails).HasForeignKey(od => od.OrderId);

            //builder.HasOne(od => od.Product).WithMany().HasForeignKey(od => od.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
