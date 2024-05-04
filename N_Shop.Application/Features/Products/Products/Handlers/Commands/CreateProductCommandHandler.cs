using MediatR;
using AutoMapper;
using N_Shop.Application.Features.Products.Products.Requests.Commands;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Responses;
using N_Shop.Application.DTOs.Products.Product.Validators;
using N_Shop.Domain.Products;
using N_Shop.Application.Contracts.Infrastructure.GUID;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.Contracts.Accessor;
using N_Shop.Application.Exceptions;

namespace N_Shop.Application.Features.Products.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICodeGenerate _codeGenerate;
        private readonly IUserAccessor _userAccessor;
        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, ICodeGenerate codeGenerate, IUserAccessor userAccessor)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _codeGenerate = codeGenerate;
            _userAccessor = userAccessor;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            #region Cheak HttpContext

            var uid = request.CreateProductDto.UserId;

            if (uid != null && uid != 0)
                if (_userAccessor.UserId != uid)
                    throw new BadRequestException($"Create Product Failed {_userAccessor.UserId} != {uid}");

            #endregion

            var response = new BaseCommandResponse();

            var validator = new CreateProductDtoValidator(_categoryRepository, _userRepository);

            var validatorResult = await validator.ValidateAsync(request.CreateProductDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Create Product Failed.";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Product>(request.CreateProductDto);
                product.ProductUniqId = _codeGenerate.GenerateGUID();
                product = await _productRepository.Add(product);
                response.Success = true;
                response.Message = "Create Product Successful.";
                response.Id = product.Id;
            }
            return response;
        }
    }
}
