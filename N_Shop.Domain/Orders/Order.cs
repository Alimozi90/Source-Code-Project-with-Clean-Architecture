using N_Shop.Domain.Common;
using N_Shop.Domain.Users;

namespace N_Shop.Domain.Orders
{
    public class Order : BaseDomainEntity
    {
        public string OrderUniqId { get; set; }
        public int OrderSum { get; set; }
        public bool IsFinally { get; set; }

        #region Relations
        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}
