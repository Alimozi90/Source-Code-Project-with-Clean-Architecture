using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using N_Shop.Application.DTOs.Role_Permissions.RolePermission;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Queries;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Features.Role_Permissions.RolePermissions.Handlers.Queries
{
    public class GetRolePermissionListRequestHandler : IRequestHandler<GetRolePermissionListRequest, RolePermissionDto>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        public GetRolePermissionListRequestHandler(IMapper mapper, IRoleRepository roleRepository, IPermissionRepository permissionRepository, IRolePermissionRepository rolePermissionRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }
        public async Task<RolePermissionDto> Handle(GetRolePermissionListRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.Get(request.Id);

            if (role == null)
                throw new NotFoundException(nameof(Role), request.Id);

            var permissions = await _permissionRepository.GetAll();

            var rolePermissions = await _rolePermissionRepository.GetPermissionsByRoleId(request.Id);

            var rolePermissionsId = rolePermissions.Select(rp => rp.PermissionId).ToList();

            return new RolePermissionDto()
            {
                Id = role.Id,
                RoleName = role.Name,
                PermissionDtos = _mapper.Map<List<PermissionDto>>(permissions),
                PermissionsId = rolePermissionsId
            };
        }
    }
}
