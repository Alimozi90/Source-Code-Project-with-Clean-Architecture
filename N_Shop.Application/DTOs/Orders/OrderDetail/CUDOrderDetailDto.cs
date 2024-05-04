namespace N_Shop.Application.DTOs.Orders.OrderDetail
{
    public class CUDOrderDetailDto : IOrderDetailDto
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
