using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Handlers.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {

            var role = await _roleRepository.Get(request.Id);

            if (role == null)
                throw new NotFoundException(nameof(Role), request.Id);

            await _roleRepository.Delete(role);
            return Unit.Value;
        }
    }

}
