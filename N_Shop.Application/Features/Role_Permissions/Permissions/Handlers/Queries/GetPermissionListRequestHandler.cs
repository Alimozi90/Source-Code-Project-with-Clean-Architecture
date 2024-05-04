using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Queries;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Handlers.Queries
{
    public class GetPermissionListRequestHandler : IRequestHandler<GetPermissionListRequest, List<PermissionDto>>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public GetPermissionListRequestHandler(IMapper mapper, IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<List<PermissionDto>> Handle(GetPermissionListRequest request, CancellationToken cancellationToken)
        {
            var permissions = await _permissionRepository.GetAll();
            return _mapper.Map<List<PermissionDto>>(permissions);
        }
    }
}
