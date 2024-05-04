using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;

namespace N_Shop.Application.DTOs.Products.ProductCommentVote.Validators
{
    public class CUDProductCommentVoteDtoValidator : AbstractValidator<CUDProductCommentVoteDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        public CUDProductCommentVoteDtoValidator(IUserRepository userRepository, IProductCommentRepository productCommentRepository)
        {
            _userRepository = userRepository;
            _productCommentRepository = productCommentRepository;

            Include(new IProductCommentVoteDtoValidator(_userRepository, _productCommentRepository));

            RuleFor(pv => pv.Vote)
                .NotNull()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
