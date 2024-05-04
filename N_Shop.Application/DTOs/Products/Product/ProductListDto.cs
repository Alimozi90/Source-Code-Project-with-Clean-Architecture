using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Products.Category;

namespace N_Shop.Application.DTOs.Products.Product
{
    public class ProductListDto : BaseDto
    {
        public string Name { get; set; }
        public string? Pictures { get; set; }
        public int Price { get; set; }
        public CategoryDto Category { get; set; }
    }
}
