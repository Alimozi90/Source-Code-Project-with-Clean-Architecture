using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.DTOs.Users.Wallet;
using MediatR;
using N_Shop.Application.Features.Users.Wallets.Requests.Queries;

namespace N_Shop.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<WalletController>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<WalletDto>>> Get(int id)
        {
            var wallets = await _mediator.Send(new GetWalletListRequest()
            {
                UserId = id,
            });
            return Ok(wallets);
        }
        // set permission 
        [HttpGet("ForAdmin/{id}")]
        public async Task<ActionResult<List<WalletDto>>> GetForAdmin(int id)
        {
            var wallets = await _mediator.Send(new GetWalletListRequest()
            {
                UserId = id,
                ShowAdmin = true
            });
            return Ok(wallets);
        }
    }
}
