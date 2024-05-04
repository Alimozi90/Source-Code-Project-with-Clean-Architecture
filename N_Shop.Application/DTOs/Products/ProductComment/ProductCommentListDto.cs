using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Users.User;

namespace N_Shop.Application.DTOs.Products.ProductComment
{
    public class ProductCommentListDto : BaseDto, IProductCommentDto
    {
        public string ProductCommentUniqId { get; set; }
        public string Comment { get; set; }
        public int? ParentId { get; set; }
        #region Relations
        public UserProfileDto User { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        #endregion
    }
}
