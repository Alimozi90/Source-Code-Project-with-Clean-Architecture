using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Role_Permissions.RolePermission;
using MediatR;
using N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Queries;
using N_Shop.Application.Responses;
using N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Commands;

namespace N_Shop.Api.Controllers.RolePermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolePermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<RolePermissionController>
        [HttpGet("roleId")]
        public async Task<ActionResult<List<RolePermissionDto>>> Get(int roleId)
        {
            var rolePermissions = await _mediator.Send(new GetRolePermissionListRequest() { Id = roleId });
            return Ok(rolePermissions);
        }

        // POST api/<RolePermissionController>
        [HttpPost]
        public async Task<ActionResult> CUD(CUDRolePermissionDto cUDRolePermissionDto)
        {
            var command = new CUDRolePermissionCommand()
            {
                CUDRolePermissionDto = cUDRolePermissionDto
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
