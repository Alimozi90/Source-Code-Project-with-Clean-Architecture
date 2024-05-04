namespace N_Shop.Application.DTOs.Products.ProductComment
{
    public interface IProductCommentDto
    {
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
