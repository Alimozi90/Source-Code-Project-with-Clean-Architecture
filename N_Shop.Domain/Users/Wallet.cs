using N_Shop.Domain.Common;

namespace N_Shop.Domain.Users
{
    public class Wallet : BaseDomainEntity
    {
        public string WalletUniqId { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public bool IsPay { get; set; }

        #region Relations
        public User User { get; set; }
        public int UserId { get; set; }
        public WalletType WalletType { get; set; }
        public int WalletTypeId { get; set; }
        #endregion
    }
}
