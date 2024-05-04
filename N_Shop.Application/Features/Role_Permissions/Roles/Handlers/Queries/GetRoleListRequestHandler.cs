using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Role;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Queries;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Handlers.Queries
{
    public class GetRoleListRequestHandler : IRequestHandler<GetRoleListRequest, List<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetRoleListRequestHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAll();
            return _mapper.Map<List<RoleDto>>(roles);
        }
    }
}
