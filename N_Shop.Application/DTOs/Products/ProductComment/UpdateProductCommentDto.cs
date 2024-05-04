using N_Shop.Application.DTOs.Common;

namespace N_Shop.Application.DTOs.Products.ProductComment
{
    public class UpdateProductCommentDto : BaseDto, IProductCommentDto
    {
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
