using MediatR;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands
{
    public class DeletePermissionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
   
}
