using N_Shop.Domain.Common;
using N_Shop.Domain.Users;

namespace N_Shop.Domain.Products
{
    public class ProductComment : BaseDomainEntity
    {
        public string ProductCommentUniqId { get; set; }
        public string Comment { get; set; }
        public bool? Accepted { get; set; }

        #region Relations
        public User User { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ProductComment? ParentProductComment { get; set; }
        public int? ParentId { get; set; }
        //public ICollection<ProductCommentVote> ProductCommentVotes { get; set; }
        #endregion
    }
}
