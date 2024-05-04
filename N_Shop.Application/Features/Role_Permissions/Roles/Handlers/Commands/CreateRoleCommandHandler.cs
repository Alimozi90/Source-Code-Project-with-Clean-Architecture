using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Role.Validators;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands;
using N_Shop.Application.Responses;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Features.Role_Permissions.Roles.Handlers.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, BaseCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public CreateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateRoleDtoValidator(_roleRepository);

            var validatorResult = await validator.ValidateAsync(request.CreateRoleDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Create Role Failed.";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var role = _mapper.Map<Role>(request.CreateRoleDto);
                role = await _roleRepository.Add(role);
                response.Success = true;
                response.Message = "Create Role Successful.";
                response.Id = role.Id;
            }
           
            return response;
        }
    }
}
