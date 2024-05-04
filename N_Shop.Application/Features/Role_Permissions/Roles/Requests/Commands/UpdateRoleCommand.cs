using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.Role;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands
{
    public class UpdateRoleCommand : IRequest<Unit>
    {
        public UpdateRoleDto UpdateRoleDto { get; set; }
    }
}
