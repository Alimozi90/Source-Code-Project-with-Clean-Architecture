using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using MediatR;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Queries;
using N_Shop.Application.Responses;
using N_Shop.Application.Features.Role_Permissions.Permissions.Requests.Commands;

namespace N_Shop.Api.Controllers.RolePermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PermissionController>
        [HttpGet]
        public async Task<ActionResult<List<PermissionDto>>> Get()
        {
            var roles = await _mediator.Send(new GetPermissionListRequest());
            return Ok(roles);
        }

        // POST api/<PermissionController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePermissionDto createPermissionDto)
        {
            var command = new CreatePermissionCommand()
            {
                CreatePermissionDto = createPermissionDto
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUI api/<PermissionController>/id
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var command = new UpdatePermissionCommand()
            {
                UpdatePermissionDto = updatePermissionDto
            };
            await _mediator.Send(command);
            return NoContent();
        }
        // Delete api/<PermissionController>/id
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePermissionCommand()
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
