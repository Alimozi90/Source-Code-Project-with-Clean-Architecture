using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.Permission.Validators
{
    public class UpdatePermissionDtoValidator : AbstractValidator<UpdatePermissionDto>
    {
        private readonly IPermissionRepository _permissionRepository;
        public UpdatePermissionDtoValidator(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

            Include(new IPermissionDtoValidator(_permissionRepository));

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var permission = await _permissionRepository.Exist(id);
                    return permission;
                })
                .WithMessage("{PropertyName} does not exist.");
        }

    }
}
