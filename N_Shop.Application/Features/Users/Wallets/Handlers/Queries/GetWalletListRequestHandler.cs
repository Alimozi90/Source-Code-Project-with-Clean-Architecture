using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Accessor;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.DTOs.Users.Wallet;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Users.Wallets.Requests.Queries;
using N_Shop.Domain.Users;

namespace N_Shop.Application.Features.Users.Wallets.Handlers.Queries
{
    public class GetWalletListRequestHandler : IRequestHandler<GetWalletListRequest, List<WalletDto>>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        public GetWalletListRequestHandler(IWalletRepository walletRepository, IMapper mapper, IUserAccessor userAccessor)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<List<WalletDto>> Handle(GetWalletListRequest request, CancellationToken cancellationToken)
        {
            if (request.ShowAdmin == false)
            {
                #region Cheak HttpContext
                var uid = request.UserId;
                if (uid == null && uid == 0)
                    throw new NotFoundException($"Get {nameof(Wallet)} Failed {uid} is null or 0", request.UserId);
                if (_userAccessor.UserId != uid)
                    throw new BadRequestException($"Get Wallet Failed {_userAccessor.UserId} != {uid}");
                #endregion

            }

            var wallets = await _walletRepository.GetWalletWithDetails(request.UserId);
            return _mapper.Map<List<WalletDto>>(wallets);
        }
    }
}
