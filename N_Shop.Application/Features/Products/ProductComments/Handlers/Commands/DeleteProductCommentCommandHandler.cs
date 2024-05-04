using MediatR;
using N_Shop.Application.Features.Products.ProductComments.Requests.Commands;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Domain.Products;
using N_Shop.Application.Exceptions;

namespace N_Shop.Application.Features.Products.ProductComments.Handlers.Commands
{
    public class DeleteProductCommentCommandHandler : IRequestHandler<DeleteProductCommentCommand, Unit>
    {
        private readonly IProductCommentRepository _productCommentRepository;
        public DeleteProductCommentCommandHandler(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommentCommand request, CancellationToken cancellationToken)
        {
            var productComment = await _productCommentRepository.Get(request.Id);

            if (productComment == null)
                throw new NotFoundException(nameof(ProductComment), request.Id);

            await _productCommentRepository.Delete(productComment);

            return Unit.Value;
        }
    }
}
