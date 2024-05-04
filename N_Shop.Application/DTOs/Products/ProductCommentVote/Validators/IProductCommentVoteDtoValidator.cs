using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductCommentVote.Validators
{
    public class IProductCommentVoteDtoValidator : AbstractValidator<IProductCommentVoteDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        public IProductCommentVoteDtoValidator(IUserRepository userRepository, IProductCommentRepository productCommentRepository)
        {
            _userRepository = userRepository;
            _productCommentRepository = productCommentRepository;

            RuleFor(pv => pv.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var user = await _userRepository.Exist(id);
                    return user;
                })
                .WithMessage("{PropertyName} does not exist.");


            RuleFor(pv => pv.ProductCommentId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var productComment = await _productCommentRepository.Exist(id);
                    return productComment;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
