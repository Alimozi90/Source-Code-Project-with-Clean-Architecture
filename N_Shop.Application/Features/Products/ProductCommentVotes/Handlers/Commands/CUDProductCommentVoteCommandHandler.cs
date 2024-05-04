using MediatR;
using N_Shop.Application.Features.Products.ProductCommentVotes.Requests.Commands;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;
using AutoMapper;
using N_Shop.Application.DTOs.Products.ProductCommentVote.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Domain.Products;
using N_Shop.Application.Contracts.Accessor;

namespace N_Shop.Application.Features.Products.ProductCommentVotes.Handlers.Queries
{
    public class CUDProductCommentVoteCommandHandler : IRequestHandler<CUDProductCommentVoteCommand, Unit>
    {
        private readonly IProductCommentVoteRepository _productCommentVoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        public CUDProductCommentVoteCommandHandler(IProductCommentVoteRepository productCommentVoteRepository, IUserRepository userRepository, IProductCommentRepository productCommentRepository, IMapper mapper, IUserAccessor userAccessor)
        {
            _productCommentVoteRepository = productCommentVoteRepository;
            _userRepository = userRepository;
            _productCommentRepository = productCommentRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(CUDProductCommentVoteCommand request, CancellationToken cancellationToken)
        {
            #region Cheak HttpContext

            var uid = request.CUDProductCommentVoteDto.UserId;

            if (_userAccessor.UserId != uid)
                throw new BadRequestException($"CUD ProductCommentVote Failed {_userAccessor.UserId} != {uid}");

            #endregion

            var validator = new CUDProductCommentVoteDtoValidator(_userRepository, _productCommentRepository);

            var validatorResult = await validator.ValidateAsync(request.CUDProductCommentVoteDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);


            var productCommentVoteMapper = _mapper.Map<ProductCommentVote>(request.CUDProductCommentVoteDto);

            var productCommentVote = await _productCommentVoteRepository.GetProductCommentVote(productCommentVoteMapper);

            if (productCommentVote == null)
                await _productCommentVoteRepository.Add(productCommentVoteMapper);

            else
            {
                if (productCommentVote.Vote == productCommentVoteMapper.Vote)
                    await _productCommentVoteRepository.Delete(productCommentVote);

                else if (productCommentVote.Vote != productCommentVoteMapper.Vote)
                {
                    await _productCommentVoteRepository.ChangeVoteProductCommentVote(productCommentVote, productCommentVoteMapper.Vote);
                }
            }


            return Unit.Value;
        }
    }
}
