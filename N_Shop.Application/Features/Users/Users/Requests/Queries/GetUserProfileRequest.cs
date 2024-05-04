using MediatR;
using N_Shop.Application.DTOs.Users.User;

namespace N_Shop.Application.Features.Users.Users.Requests.Queries
{
    public class GetUserProfileRequest : IRequest<UserProfileDto>
    {
        public int Id { get; set; }
    }
}
