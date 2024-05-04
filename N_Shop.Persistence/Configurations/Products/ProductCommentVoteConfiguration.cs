using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Shop.Domain.Products;

namespace N_Shop.Persistence.Configurations.Products
{
    public class ProductCommentVoteConfiguration : IEntityTypeConfiguration<ProductCommentVote>
    {
        public void Configure(EntityTypeBuilder<ProductCommentVote> builder)
        {
            //builder.HasOne(pcv => pcv.ProductComment).WithMany(pcv => pcv.ProductCommentVotes).HasForeignKey(pcv => pcv.ProductCommentId);

            //builder.HasOne(o => o.User).WithMany().HasForeignKey(pcv => pcv.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
