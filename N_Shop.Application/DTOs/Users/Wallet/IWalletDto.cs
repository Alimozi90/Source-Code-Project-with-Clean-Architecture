
namespace N_Shop.Application.DTOs.Users.Wallet
{
    public interface IWalletDto
    {
        public int Amount { get; set; }
        public string? Description { get; set; }
        public bool IsPay { get; set; }
    }
}
