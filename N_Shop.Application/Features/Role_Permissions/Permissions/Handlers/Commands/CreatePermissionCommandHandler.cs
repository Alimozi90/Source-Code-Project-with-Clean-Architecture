using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Permission.Validators;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands;
using N_Shop.Application.Responses;
using N_Shop.Domain.Role_Permissions;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Handlers.Commands
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, BaseCommandResponse>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public CreatePermissionCommandHandler(IMapper mapper, IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreatePermissionDtoValidator(_permissionRepository);

            var validatorResult = await validator.ValidateAsync(request.CreatePermissionDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Create Permission Failed.";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var permission = _mapper.Map<Permission>(request.CreatePermissionDto);
                permission = await _permissionRepository.Add(permission);
                response.Success = true;
                response.Message = "Create Permission Successful.";
                response.Id = permission.Id;
            }
            return response;
        }
    }
}
