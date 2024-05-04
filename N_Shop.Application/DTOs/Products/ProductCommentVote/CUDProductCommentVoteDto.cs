
namespace N_Shop.Application.DTOs.Products.ProductCommentVote
{
    public class CUDProductCommentVoteDto : IProductCommentVoteDto
    {
        public bool Vote { get; set; }
        public int ProductCommentId { get; set; }
        public int UserId { get; set; }
    }
}
