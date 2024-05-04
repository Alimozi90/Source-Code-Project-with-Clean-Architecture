namespace N_Shop.Application.DTOs.Products.Product
{
    public interface IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Pictures { get; set; }
        public string? Tags { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int? UserId { get; set; }

    }
}
