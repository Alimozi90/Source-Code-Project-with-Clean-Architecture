using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Role_Permissions.Role;
using MediatR;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Queries;
using N_Shop.Application.Responses;
using N_Shop.Application.Features.Role_Permissions.Roles.Requests.Commands;

namespace N_Shop.Api.Controllers.RolePermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> Get()
        {
            var roles = await _mediator.Send(new GetRoleListRequest());
            return Ok(roles);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRoleDto createRoleDto)
        {
            var command = new CreateRoleCommand() { CreateRoleDto = createRoleDto };
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        // PUT api/<RoleController>/id
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateRoleDto updateRoleDto)
        {
            var command = new UpdateRoleCommand() { UpdateRoleDto = updateRoleDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<RoleController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteRoleCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
