using MediatR;
using AutoMapper;
using N_Shop.Application.Features.Products.ProductComments.Requests.Commands;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.Responses;
using N_Shop.Application.DTOs.Products.ProductComment.Validators;
using N_Shop.Domain.Products;
using N_Shop.Application.Contracts.Infrastructure.GUID;
using Microsoft.AspNetCore.Http;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Contracts.Accessor;

namespace N_Shop.Application.Features.Products.ProductComments.Handlers.Commands
{
    public class CreateProductCommentCommandHandler : IRequestHandler<CreateProductCommentCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly ICodeGenerate _codeGenerate;
        private readonly IUserAccessor _userAccessor;
        public CreateProductCommentCommandHandler(IMapper mapper, IProductRepository productRepository, IUserRepository userRepository, IProductCommentRepository productCommentRepository, ICodeGenerate codeGenerate, IUserAccessor userAccessor)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productCommentRepository = productCommentRepository;
            _codeGenerate = codeGenerate;
            _userAccessor = userAccessor;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommentCommand request, CancellationToken cancellationToken)
        {

            #region Cheak HttpContext

            var uid = request.CreateProductCommentDto.UserId;

            if (_userAccessor.UserId != uid)
                throw new BadRequestException($"Create ProductComment Failed {_userAccessor.UserId} != {uid}");

            #endregion

            var response = new BaseCommandResponse();

            var validator = new CreateProductCommentDtoValidator(_userRepository, _productRepository, _productCommentRepository);

            var validatorResult = await validator.ValidateAsync(request.CreateProductCommentDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Create ProductComment Failed.";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var productComment = _mapper.Map<ProductComment>(request.CreateProductCommentDto);
                if (productComment.ParentId == 0)
                    productComment.ParentId = null;
                productComment.ProductCommentUniqId = _codeGenerate.GenerateGUID();
                productComment = await _productCommentRepository.Add(productComment);
                response.Success = true;
                response.Message = "Create ProductComment Successful.";
                response.Id = productComment.Id;
            }
            return response;
        }
    }
}
