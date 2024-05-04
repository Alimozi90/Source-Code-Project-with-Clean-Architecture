using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.DTOs.Role_Permissions.Permission.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands;

namespace N_Shop.Application.Features.Role_Permissions.Permissions.Handlers.Commands
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, Unit>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public UpdatePermissionCommandHandler(IMapper mapper, IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<Unit> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePermissionDtoValidator(_permissionRepository);

            var validatorResult = await validator.ValidateAsync(request.UpdatePermissionDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var permission = await _permissionRepository.Get(request.UpdatePermissionDto.Id);
            _mapper.Map(request.UpdatePermissionDto, permission);
            await _permissionRepository.Update(permission);
            return Unit.Value;
        }
    }
}
