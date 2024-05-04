using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using N_Shop.Application.DTOs.Orders.OrderDetail;
using N_Shop.Application.Features.Orders.Orders.Requests.Queries;
using N_Shop.Application.Features.Orders.Orders.Requests.Commands;

namespace N_Shop.Api.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet("userId")]
        public async Task<ActionResult<List<OrderDetailDto>>> Get(int userId)
        {
            var orders = await _mediator.Send(new GetOrderListRequest() { UserId = userId });
            return Ok(orders);
        }

        // GET: api/<OrderController>
        [HttpGet("ForAdmin/userId")]
        public async Task<ActionResult<List<OrderDetailDto>>> GetForAdmin(int userId)
        {
            var orders = await _mediator.Send(new GetOrderListRequest()
            {
                UserId = userId,
                ShowAdmin = true
            });
            return Ok(orders);
        }

        // GET: api/<OrderController>
        [HttpGet("id/userId")]
        public async Task<ActionResult<List<OrderDetailDto>>> Get(int id, int userId)
        {
            var order = await _mediator.Send(new GetOrderRequest()
            {
                Id = id,
                UserId = userId,
            });
            return Ok(order);
        }

        // GET: api/<OrderController>
        [HttpGet("ForAdmin/id/userId")]
        public async Task<ActionResult<List<OrderDetailDto>>> GetForAdmin(int id, int userId)
        {
            var order = await _mediator.Send(new GetOrderRequest()
            {
                Id = id,
                UserId = userId,
                ShowAdmin = true
            });
            return Ok(order);
        }

        // POST api/<RolePermissionController>
        [HttpPost]
        public async Task<ActionResult> CUD(CUDOrderDetailDto cUDOrderDetailDto)
        {
            var command = new CUDOrderCommand()
            {
                CUDOrderDetailDto = cUDOrderDetailDto
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
