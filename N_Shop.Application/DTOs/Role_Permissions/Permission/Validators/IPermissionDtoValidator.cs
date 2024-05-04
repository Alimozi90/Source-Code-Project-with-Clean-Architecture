using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.Permission.Validators
{
    public class IPermissionDtoValidator : AbstractValidator<IPermissionDto>
    {
        private readonly IPermissionRepository _permissionRepository;
        public IPermissionDtoValidator(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var permission = await _permissionRepository.ExistPermissionName(id);
                    return !permission;
                })
                .WithMessage("{PropertyName} Is Exist");

        }
    }
}
