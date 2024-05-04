using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.Role.Validators
{
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        public UpdateRoleDtoValidator(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

            Include(new IRoleDtoValidator(_roleRepository));

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var permission = await _roleRepository.Exist(id);
                    return permission;
                })
                .WithMessage("{PropertyName} does not exist.");
        }

    }
}
