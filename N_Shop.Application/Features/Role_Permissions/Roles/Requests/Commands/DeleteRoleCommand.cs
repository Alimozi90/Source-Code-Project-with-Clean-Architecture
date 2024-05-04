using MediatR;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands
{
    public class DeleteRoleCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
   
}
