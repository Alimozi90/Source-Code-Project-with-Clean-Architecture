using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Products.Category;
using MediatR;
using N_Shop.Application.Features.Products.Categories.Requests.Queries;
using N_Shop.Application.Responses;
using N_Shop.Application.Features.Products.Categories.Requests.Commands;
using Microsoft.AspNetCore.Authorization;
using N_Shop.Application.Helpers.Attributes;

namespace N_Shop.Api.Controllers.Products
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CategoryController>
        //[AllowAnonymous]
        //[CheckPermission(1)]
        //[CheckPermission(1)]
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var categories = await _mediator.Send(new GetCategoryListRequest());
            return Ok(categories);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCategoryDto createCategoryDto)
        {
            var command = new CreateCategoryCommand() { CreateCategoryDto = createCategoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        // PUT api/<CategoryController>/id
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = new UpdateCategoryCommand() { UpdateCategoryDto = updateCategoryDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CategoryController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
