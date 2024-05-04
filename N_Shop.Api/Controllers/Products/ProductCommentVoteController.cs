using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Products.ProductCommentVote;
using MediatR;
using N_Shop.Application.Features.Products.ProductCommentVotes.Requests.Queries;
using N_Shop.Application.Features.Products.ProductCommentVotes.Requests.Commands;

namespace N_Shop.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCommentVoteController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductCommentVoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductCommentVoteController>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCommentVoteDto>> Get(int id)
        {
            var productCommentVote = await _mediator.Send(new GetProductCommentVoteRequest() { Id = id });
            return Ok(productCommentVote);
        }

        // POST api/<ProductCommentVoteController>
        [HttpPost]
        public async Task<ActionResult> CUD(CUDProductCommentVoteDto cUDProductCommentVoteDto)
        {
            var command = new CUDProductCommentVoteCommand()
            {
                CUDProductCommentVoteDto = cUDProductCommentVoteDto
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
