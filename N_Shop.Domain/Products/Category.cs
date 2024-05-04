using N_Shop.Domain.Common;

namespace N_Shop.Domain.Products
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }

        //#region Relations
        //public ICollection<Product> Products { get; set; }
        //#endregion
    }
}
