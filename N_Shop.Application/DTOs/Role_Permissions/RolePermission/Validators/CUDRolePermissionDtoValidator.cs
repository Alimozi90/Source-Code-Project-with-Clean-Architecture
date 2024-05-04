using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.RolePermission.Validators
{
    public class CUDRolePermissionDtoValidator : AbstractValidator<CUDRolePermissionDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        public CUDRolePermissionDtoValidator(IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;

            _permissionRepository = permissionRepository;

            Include(new IRolePermissionDtoValidator(_permissionRepository));

            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var role = await _roleRepository.Exist(id);
                    return role;
                })
                .WithMessage("{PropertyName} does not exist.");
        }

    }
}
