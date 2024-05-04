using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.RolePermission.Validators
{
    public class IRolePermissionDtoValidator : AbstractValidator<IRolePermissionDto>
    {
        private readonly IPermissionRepository _permissionRepository;
        public IRolePermissionDtoValidator(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

            RuleFor(p => p.PermissionsId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (ids, token) =>
                {
                    foreach (var id in ids)
                    {
                        var permission = await _permissionRepository.Exist(id);
                        if (permission == false)
                            return false;
                    }
                    return true;
                })
               .WithMessage("{PropertyName} does not exist.");
        }

    }
}
