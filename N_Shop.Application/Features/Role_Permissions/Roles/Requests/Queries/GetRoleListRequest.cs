using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.Role;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Requests.Queries
{
    public class GetRoleListRequest : IRequest<List<RoleDto>>
    {
    }
}
