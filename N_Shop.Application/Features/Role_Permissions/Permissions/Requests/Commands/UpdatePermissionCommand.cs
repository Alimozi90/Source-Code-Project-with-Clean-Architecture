using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.Permission;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands
{
    public class UpdatePermissionCommand : IRequest<Unit>
    {
        public UpdatePermissionDto UpdatePermissionDto { get; set; }
    }
}
