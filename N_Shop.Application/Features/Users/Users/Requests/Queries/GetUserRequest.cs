using MediatR;
using N_Shop.Application.DTOs.Users.User;

namespace N_Shop.Application.Features.Users.Users.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
