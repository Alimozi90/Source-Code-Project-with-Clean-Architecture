using N_Shop.Domain.Common;
using N_Shop.Domain.Users;

namespace N_Shop.Domain.Products
{
    public class ProductVote : BaseDomainEntity
    {
        public bool Vote { get; set; }
        #region Relations
        public User User { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        #endregion
    }
}
