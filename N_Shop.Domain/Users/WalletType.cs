using N_Shop.Domain.Common;

namespace N_Shop.Domain.Users
{
    public class WalletType : BaseDomainEntity
    {
        public string Name { get; set; }

        //#region Relations
        //public ICollection<Wallet> Wallets { get; set; }
        //#endregion
    }
}
