using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Users.User;
using N_Shop.Application.DTOs.Users.WalletType;

namespace N_Shop.Application.DTOs.Users.Wallet
{
    public class WalletDto : BaseDto, IWalletDto
    {
        public string WalletUniqId { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public bool IsPay { get; set; }

        #region Relations
        public UserProfileDto User { get; set; }
        public WalletTypeDto WalletType { get; set; }
        #endregion
    }
}
