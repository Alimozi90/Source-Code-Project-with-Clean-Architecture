using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.Permission;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Queries
{
    public class GetPermissionListRequest : IRequest<List<PermissionDto>>
    {
    }
}
