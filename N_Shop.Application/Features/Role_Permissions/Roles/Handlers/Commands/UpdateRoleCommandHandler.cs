using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Role.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Handlers.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UpdateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoleDtoValidator(_roleRepository);

            var validatorResult = await validator.ValidateAsync(request.UpdateRoleDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var role = await _roleRepository.Get(request.UpdateRoleDto.Id);
            _mapper.Map(request.UpdateRoleDto, role);
            await _roleRepository.Update(role);
            return Unit.Value;
        }
    }
}
