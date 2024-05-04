using N_Shop.Domain.Common;
using N_Shop.Domain.Orders;
using N_Shop.Domain.Users;

namespace N_Shop.Domain.Products
{
    public class Product : BaseDomainEntity
    {
        public string ProductUniqId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Pictures { get; set; }
        public string? Tags { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

        #region Relations
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
        //public ICollection<ProductComment> ProductComments { get; set; }
        //public ICollection<ProductVote> ProductVotes { get; set; }
        #endregion
    }
}
