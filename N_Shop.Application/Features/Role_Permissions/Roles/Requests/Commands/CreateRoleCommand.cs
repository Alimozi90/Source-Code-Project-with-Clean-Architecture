using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.Role;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands
{
    public class CreateRoleCommand : IRequest<BaseCommandResponse>
    {
        public CreateRoleDto CreateRoleDto { get; set; }
    }
}
