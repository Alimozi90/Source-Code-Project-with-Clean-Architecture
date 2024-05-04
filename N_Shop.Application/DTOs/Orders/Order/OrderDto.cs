using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Orders.OrderDetail;
using N_Shop.Application.DTOs.Users.User;

namespace N_Shop.Application.DTOs.Orders.Order
{
    public class OrderDto : BaseDto
    {
        public string OrderUniqId { get; set; }
        public int OrderSum { get; set; }
        #region Relations
        public UserProfileDto User { get; set; }
        public List<OrderDetailDto> OrderDetail { get; set; }
        #endregion
    }
}
