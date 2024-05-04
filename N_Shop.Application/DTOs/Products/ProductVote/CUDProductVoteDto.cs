
namespace N_Shop.Application.DTOs.Products.ProductVote
{
    public class CUDProductVoteDto : IProductVoteDto
    {
        public bool Vote { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
