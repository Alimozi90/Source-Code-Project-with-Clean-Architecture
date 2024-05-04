using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Products.Product;
namespace N_Shop.Application.DTOs.Orders.OrderDetail
{
    public class OrderDetailDto : BaseDto, IOrderDetailDto
    {
        public int Count { get; set; }
        public int Price { get; set; }
        #region Relations
        public ProductListDto Product { get; set; }
        #endregion
    }
}
