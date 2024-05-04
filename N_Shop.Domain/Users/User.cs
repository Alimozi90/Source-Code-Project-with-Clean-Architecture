using N_Shop.Domain.Common;
using N_Shop.Domain.Orders;
using N_Shop.Domain.Products;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Domain.Users
{
    public class User : BaseDomainEntity
    {
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        public string? Avatar { get; set; }
        public string? ActiveCode { get; set; }
        public bool? IsActive { get; set; }
        public byte Status { get; set; }

        #region Relations
        public Role Role { get; set; }
        public int RoleId { get; set; }
        //public ICollection<Order> Orders { get; set; }
        //public ICollection<Product>? Products { get; set; }
        //public ICollection<ProductComment> ProductComments { get; set; }
        //public ICollection<ProductCommentVote> ProductCommentVotes { get; set; }
        //public ICollection<ProductVote> ProductVotes { get; set; }
        //public ICollection<Wallet> Wallets { get; set; }
        #endregion
    }
}
