using MediatR;
using AutoMapper;
using N_Shop.Application.Features.Products.ProductComments.Requests.Commands;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.DTOs.Products.ProductComment.Validators;
using N_Shop.Domain.Products;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Contracts.Accessor;

namespace N_Shop.Application.Features.Products.ProductComments.Handlers.Commands
{
    public class UpdateProductCommentCommandHandler : IRequestHandler<UpdateProductCommentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IUserAccessor _userAccessor;
        public UpdateProductCommentCommandHandler(IMapper mapper, IProductRepository productRepository, IUserRepository userRepository, IProductCommentRepository productCommentRepository, IUserAccessor userAccessor)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productCommentRepository = productCommentRepository;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(UpdateProductCommentCommand request, CancellationToken cancellationToken)
        {
            #region Cheak HttpContext

            if (request.UpdateProductCommentDto != null)
            {
                var uid = request.UpdateProductCommentDto.UserId;
                if (uid != null && uid != 0)
                    throw new NotFoundException($"Update {nameof(ProductComment)} Failed {uid} is null or 0", uid);
                if (_userAccessor.UserId != uid)
                    throw new BadRequestException($"Update ProductComment Failed {_userAccessor.UserId} != {uid}");
            }

            #endregion

            var productComment = await _productCommentRepository.Get(request.Id);

            if (productComment == null)
                throw new NotFoundException(nameof(ProductComment), request.Id);

            if (request.UpdateProductCommentDto != null)
            {
                var validator = new UpdateProductCommentDtoValidator(_userRepository, _productRepository, _productCommentRepository);

                var validatorResult = await validator.ValidateAsync(request.UpdateProductCommentDto);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult);

                productComment = _mapper.Map(request.UpdateProductCommentDto, productComment);

                await _productCommentRepository.Update(productComment);
            }

            else if (request.ChangeProductCommentAcceptDto != null)
            {
                await _productCommentRepository.ChangeAcceptStatus(productComment, request.ChangeProductCommentAcceptDto.Accepted);
            }

            return Unit.Value;
        }
    }
}
