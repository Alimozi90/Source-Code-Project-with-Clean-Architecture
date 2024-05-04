using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.RolePermission.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Commands;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Features.Role_Permissions.RolePermissions.Handlers.Commands
{
    public class CUDRolePermissionCommandHandler : IRequestHandler<CUDRolePermissionCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        public CUDRolePermissionCommandHandler(IRoleRepository roleRepository, IPermissionRepository permissionRepository, IRolePermissionRepository rolePermissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }
        public async Task<Unit> Handle(CUDRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CUDRolePermissionDtoValidator(_roleRepository, _permissionRepository);

            var validatorResult = await validator.ValidateAsync(request.CUDRolePermissionDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var roleId = request.CUDRolePermissionDto.Id;

            if (roleId == 0)
                throw new NotFoundException(nameof(Role), roleId);

            var PermissionsId = request.CUDRolePermissionDto.PermissionsId;

            var rolePermissions = await _rolePermissionRepository.GetPermissionsByRoleId(roleId);

            //rolePermissions.ForEach(async rp => await _rolePermissionRepository.Delete(rp));

            foreach (var item in rolePermissions)
            {
                await _rolePermissionRepository.Delete(item);
            }

            if (PermissionsId.Any() && PermissionsId.Count > 0)
            {
                foreach (var prId in PermissionsId)
                {
                    await _rolePermissionRepository.Add(new RolePermission()
                    {
                        RoleId = roleId,
                        PermissionId = prId
                    });
                }
            }

            return Unit.Value;
        }
    }
}
