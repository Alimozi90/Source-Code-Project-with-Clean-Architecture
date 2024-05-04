using AutoMapper;
using MediatR;
using N_Shop.Application.Contracts.Accessor;
using N_Shop.Application.Contracts.Persistence.Orders;
using N_Shop.Application.DTOs.Orders.Order;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Orders.Orders.Requests.Queries;

namespace N_Shop.Application.Features.Orders.Orders.Handlers.Queries
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        public GetOrderRequestHandler(IMapper mapper, IOrderRepository orderRepository, IUserAccessor userAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            if (request.ShowAdmin == false)
            {
                #region Cheak HttpContext

                var uid = request.UserId;

                if (_userAccessor.UserId != uid)
                    throw new BadRequestException($"Get Order Failed {_userAccessor.UserId} != {uid}");

                #endregion
            }

            var order = await _orderRepository.GetOrderWithDetails(request.Id, request.UserId);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
