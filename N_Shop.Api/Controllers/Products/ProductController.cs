using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Products.Product;
using MediatR;
using N_Shop.Application.Features.Products.Products.Requests.Queries;
using N_Shop.Application.Responses;
using N_Shop.Application.Features.Products.Products.Requests.Commands;

namespace N_Shop.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductListDto>>> Get()
        {
            var products = await _mediator.Send(new GetProductListRequest());
            return Ok(products);
        }

        // GET: api/<ProductController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductRequest() { Id = id });
            return Ok(product);
        }
        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto createProductDto)
        {
            var command = new CreateProductCommand() { CreateProductDto = createProductDto };
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        // PUT api/<ProductController>/id
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductDto updateProductDto)
        {
            var command = new UpdateProductCommand() { UpdateProductDto = updateProductDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProductController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
