using MediatR;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Products.Products.Requests.Commands;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Features.Products.Products.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            await _productRepository.Delete(product);

            return Unit.Value;
        }
    }
}
