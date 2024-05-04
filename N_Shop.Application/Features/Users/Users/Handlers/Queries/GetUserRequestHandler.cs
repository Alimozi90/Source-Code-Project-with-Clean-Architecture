using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.DTOs.Users.User;
using N_Shop.Application.Features.Users.Users.Requests.Queries;

namespace N_Shop.Application.Features.Users.Users.Handlers.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var userProfile = await _userRepository.Get(request.Id);
            return _mapper.Map<UserDto>(userProfile);
        }
    }
}
