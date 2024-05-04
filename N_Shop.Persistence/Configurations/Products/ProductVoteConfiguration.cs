using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Products;

namespace N_Shop.Persistence.Configurations.Products
{
    public class ProductVoteConfiguration : IEntityTypeConfiguration<ProductVote>
    {
        public void Configure(EntityTypeBuilder<ProductVote> builder)
        {
            //builder.HasOne(pv => pv.Product).WithMany(pv => pv.ProductVotes).HasForeignKey(pv => pv.ProductId);

            //builder.HasOne(pv => pv.User)
            //    .WithMany()
            //    .HasForeignKey(pv => pv.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
