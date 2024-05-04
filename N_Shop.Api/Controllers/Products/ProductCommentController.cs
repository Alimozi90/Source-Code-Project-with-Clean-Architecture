using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Products.ProductComment;
using MediatR;
using N_Shop.Application.Features.Products.ProductComments.Requests.Queries;
using N_Shop.Application.Responses;
using N_Shop.Application.Features.Products.ProductComments.Requests.Commands;

namespace N_Shop.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCommentController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductCommentController>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductCommentListDto>>> Get(int id)
        {
            var productComments = await _mediator.Send(new GetProductCommentListRequest() { ProductId = id });
            return Ok(productComments);
        }

        // GET: api/<ProductCommentController>/parentId
        [HttpGet("{id}/{parentId}")]
        public async Task<ActionResult<List<ProductCommentListDto>>> Get(int id, int parentId)
        {
            var productComments = await _mediator.Send(new GetProductCommentListRequest() { ProductId = id, ParentId = parentId });
            return Ok(productComments);
        }

        // POST api/<ProductCommentController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductCommentDto createProductCommentDto)
        {
            var command = new CreateProductCommentCommand() { CreateProductCommentDto = createProductCommentDto };
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        // PUT api/<ProductCommentController>/id
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommentDto updateProductCommentDto)
        {
            var command = new UpdateProductCommentCommand()
            {
                UpdateProductCommentDto = updateProductCommentDto,
                Id = updateProductCommentDto.Id
            };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProductCommentController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommentCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<ProductCommentController>/id
        [HttpPut("changeaccept")]
        public async Task<ActionResult> ChangeAccept([FromBody] ChangeProductCommentAcceptDto changeProductCommentAcceptDto)
        {
            var command = new UpdateProductCommentCommand()
            {
                ChangeProductCommentAcceptDto = changeProductCommentAcceptDto,
                Id = changeProductCommentAcceptDto.Id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
