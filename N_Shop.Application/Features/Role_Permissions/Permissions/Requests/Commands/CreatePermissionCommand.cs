using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands
{
    public class CreatePermissionCommand : IRequest<BaseCommandResponse>
    {
        public CreatePermissionDto CreatePermissionDto { get; set; }
    }
}
