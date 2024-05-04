using FluentValidation;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;

namespace N_Shop.Application.DTOs.Role_Permissions.Role.Validators
{
    public class IRoleDtoValidator : AbstractValidator<IRoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        public IRoleDtoValidator(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var role = await _roleRepository.ExistRoleName(id);
                    return !role;
                })
                .WithMessage("{PropertyName} Is Exist.");
                
        }
    }
}
