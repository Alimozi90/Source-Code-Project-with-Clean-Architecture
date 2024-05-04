using MediatR;
using N_Shop.Application.DTOs.Users.Wallet;

namespace N_Shop.Application.Features.Users.Wallets.Requests.Queries
{
    public class GetWalletListRequest : IRequest<List<WalletDto>>
    {
        public int UserId { get; set; }
        public bool ShowAdmin { get; set; }
    }
}
