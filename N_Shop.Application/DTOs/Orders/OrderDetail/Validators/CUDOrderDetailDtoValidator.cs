using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Orders.OrderDetail.Validators
{
    public class CUDOrderDetailDtoValidator : AbstractValidator<CUDOrderDetailDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        public CUDOrderDetailDtoValidator(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;

            Include(new IOrderDetailDtoValidator());

            RuleFor(pv => pv.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var user = await _userRepository.Exist(id);
                    return user;
                })
                .WithMessage("{PropertyName} does not exist.");


            RuleFor(pv => pv.ProductId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var product = await _productRepository.Exist(id);
                    return product;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
