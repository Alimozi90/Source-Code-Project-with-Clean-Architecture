using N_Shop.Application.DTOs.Common;

namespace N_Shop.Application.DTOs.Products.Category
{
    public class CategoryDto : BaseDto, ICategoryDto
    {
        public string Name { get; set; }
    }
}
