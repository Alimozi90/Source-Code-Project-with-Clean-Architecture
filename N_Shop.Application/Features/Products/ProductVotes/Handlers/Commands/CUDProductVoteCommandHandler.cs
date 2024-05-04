using MediatR;
using N_Shop.Application.DTOs.Products.ProductVote;
using N_Shop.Application.Features.Products.ProductVotes.Requests.Commands;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;
using AutoMapper;
using N_Shop.Application.DTOs.Products.ProductVote.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Domain.Products;
using N_Shop.Application.Contracts.Accessor;

namespace N_Shop.Application.Features.Products.ProductVotes.Handlers.Queries
{
    public class CUDProductVoteCommandHandler : IRequestHandler<CUDProductVoteCommand, Unit>
    {
        private readonly IProductVoteRepository _productVoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        public CUDProductVoteCommandHandler(IProductVoteRepository productVoteDto, IUserRepository userRepository, IProductRepository productRepository, IMapper mapper, IUserAccessor userAccessor)
        {
            _productVoteRepository = productVoteDto;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(CUDProductVoteCommand request, CancellationToken cancellationToken)
        {
            #region Cheak HttpContext

            var uid = request.CUDProductVoteDto.UserId;

            if (_userAccessor.UserId != uid)
                throw new BadRequestException($"CUD ProductVote Failed {_userAccessor.UserId} != {uid}");

            #endregion

            var validator = new CUDProductVoteDtoValidator(_userRepository, _productRepository);

            var validatorResult = await validator.ValidateAsync(request.CUDProductVoteDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);


            var productVoteMapper = _mapper.Map<ProductVote>(request.CUDProductVoteDto);

            var productVote = await _productVoteRepository.GetProductVote(productVoteMapper);

            if (productVote == null)
                await _productVoteRepository.Add(productVoteMapper);

            else
            {
                if (productVote.Vote == productVoteMapper.Vote)
                    await _productVoteRepository.Delete(productVote);

                else if (productVote.Vote != productVoteMapper.Vote)
                {
                    await _productVoteRepository.ChangeVoteProductVote(productVote, productVoteMapper.Vote);
                }
            }


            return Unit.Value;
        }
    }
}
