using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Handlers.Commands
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, Unit>
    {
        private readonly IPermissionRepository _permissionRepository;
        public DeletePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Unit> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {

            var permission = await _permissionRepository.Get(request.Id);

            if (permission == null)
                throw new NotFoundException(nameof(Permission), request.Id);

            await _permissionRepository.Delete(permission);
            return Unit.Value;
        }
    }

}
