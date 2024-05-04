using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Accessor;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.DTOs.Products.Product.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Products.Products.Requests.Commands;

namespace N_Shop.Application.Features.Products.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserAccessor _userAccessor;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IUserAccessor userAccessor)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            #region Cheak HttpContext

            var uid = request.UpdateProductDto.UserId;

            if (uid != null && uid != 0)
                if (_userAccessor.UserId != uid)
                    throw new BadRequestException($"Update Product Failed {_userAccessor.UserId} != {uid}");

            #endregion


            var validator = new UpdateProductDtoValidator(_productRepository, _categoryRepository, _userRepository);

            var validatorResult = await validator.ValidateAsync(request.UpdateProductDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var product = await _productRepository.Get(request.UpdateProductDto.Id);

            product = _mapper.Map(request.UpdateProductDto, product);

            await _productRepository.Update(product);

            return Unit.Value;
        }
    }
}
