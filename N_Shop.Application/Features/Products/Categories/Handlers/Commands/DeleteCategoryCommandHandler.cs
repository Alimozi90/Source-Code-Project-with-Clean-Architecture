using MediatR;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Products.Categories.Requests.Commands;
using N_Shop.Domain.Products;

namespace N_Shop.Application.Features.Products.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            await _categoryRepository.Delete(category);

            return Unit.Value;
        }
    }
}
