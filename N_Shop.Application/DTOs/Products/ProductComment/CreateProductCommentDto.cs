
namespace N_Shop.Application.DTOs.Products.ProductComment
{
    public class CreateProductCommentDto : IProductCommentDto
    {
        public string Comment { get; set; }
        public int? ParentId { get; set; }
        #region Relations
        public int UserId { get; set; }
        public int ProductId { get; set; }
        #endregion
    }
}
