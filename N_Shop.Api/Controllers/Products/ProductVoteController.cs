using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Products.ProductVote;
using MediatR;
using N_Shop.Application.Features.Products.ProductVotes.Requests.Queries;
using N_Shop.Application.Features.Products.ProductVotes.Requests.Commands;

namespace N_Shop.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVoteController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductVoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductVoteController>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVoteDto>> Get(int id)
        {
            var productVote = await _mediator.Send(new GetProductVoteRequest() { Id = id });
            return Ok(productVote);
        }

        // POST api/<ProductVoteController>
        [HttpPost]
        public async Task<ActionResult> CUD(CUDProductVoteDto cUDProductVoteDto)
        {
            var command = new CUDProductVoteCommand()
            {
                CUDProductVoteDto = cUDProductVoteDto
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
