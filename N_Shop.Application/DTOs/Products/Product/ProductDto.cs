using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Products.Category;
using N_Shop.Application.DTOs.Users.User;

namespace N_Shop.Application.DTOs.Products.Product
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Pictures { get; set; }
        public string? Tags { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
        public UserProfileDto? User { get; set; }
        public int? UserId { get; set; }
    }
}
