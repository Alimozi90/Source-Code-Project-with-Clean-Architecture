using N_Shop.Domain.Common;
using N_Shop.Domain.Products;

namespace N_Shop.Domain.Orders
{
    public class OrderDetail : BaseDomainEntity
    {
        public int Count { get; set; }
        public int Price { get; set; }
        #region Relations
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        #endregion
    }
}
