using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Products;

namespace N_Shop.Persistence.Configurations.Products
{
    public class ProductCommentConfiguration : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            ////builder.HasOne(pc => pc.Product).WithMany(pc => pc.ProductComments).HasForeignKey(pc => pc.ProductId);

            builder.HasOne(pc => pc.User).WithMany().HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.ParentId).IsRequired(false);

            builder.HasOne(pc => pc.ParentProductComment).WithMany().HasForeignKey(pc => pc.ParentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
