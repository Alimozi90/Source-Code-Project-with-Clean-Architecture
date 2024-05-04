using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.Permission.Validators
{
    public class CreatePermissionDtoValidator : AbstractValidator<CreatePermissionDto>
    {
        private readonly IPermissionRepository _permissionRepository;
        public CreatePermissionDtoValidator(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

            Include(new IPermissionDtoValidator(_permissionRepository));
        }
    }
}
