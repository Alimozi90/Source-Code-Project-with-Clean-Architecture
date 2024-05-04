using N_Shop.Domain.Common;
using N_Shop.Domain.Users;
namespace N_Shop.Domain.Products
{
    public class ProductCommentVote : BaseDomainEntity
    {
        public bool Vote { get; set; }
        #region Relation
        public ProductComment ProductComment { get; set; }
        public int ProductCommentId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        #endregion
    }
}
