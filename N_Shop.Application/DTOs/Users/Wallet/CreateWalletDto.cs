namespace N_Shop.Application.DTOs.Users.Wallet
{
    public class CreateWalletDto : IWalletDto
    {
        public int Amount { get; set; }
        public string? Description { get; set; }
        public bool IsPay { get; set; }

        #region Relations
        public int UserId { get; set; }
        public int WalletTypeId { get; set; }
        #endregion
    }
}
