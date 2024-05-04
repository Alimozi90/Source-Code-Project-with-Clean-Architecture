using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.RolePermission;

namespace N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Queries
{
    public class GetRolePermissionListRequest:IRequest<RolePermissionDto>
    {
        public int Id { get; set; }
    }
}
