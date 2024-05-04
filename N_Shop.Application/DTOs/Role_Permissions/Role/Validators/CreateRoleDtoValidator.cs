using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.Role.Validators
{
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        public CreateRoleDtoValidator(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

            Include(new IRoleDtoValidator(_roleRepository));
        }
    }
}
