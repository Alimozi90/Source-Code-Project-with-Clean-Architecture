using AutoMapper;
using MediatR;
using N_Shop.Application.Constants.Enums;
using N_Shop.Application.Contracts.Accessor;
using N_Shop.Application.Contracts.Infrastructure.GUID;
using N_Shop.Application.Contracts.Infrastructure.Math;
using N_Shop.Application.Contracts.Persistence.Orders;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.DTOs.Orders.OrderDetail.Validators;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Features.Orders.Orders.Requests.Commands;
using N_Shop.Domain.Orders;

namespace N_Shop.Application.Features.Orders.Orders.Handlers.Commands
{
    public class CUDOrderCommandHandler : IRequestHandler<CUDOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICodeGenerate _codeGenerate;
        private readonly IComputationsMath _computationsMath;
        private readonly IUserAccessor _userAccessor;
        public CUDOrderCommandHandler(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper, ICodeGenerate codeGenerate, IUserAccessor userAccessor, IComputationsMath computationsMath)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _codeGenerate = codeGenerate;
            _computationsMath = computationsMath;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(CUDOrderCommand request, CancellationToken cancellationToken)
        {
            #region Cheak HttpContext

            var uid = request.CUDOrderDetailDto.UserId;

            if (_userAccessor.UserId != uid)
                throw new BadRequestException($"CUD Order Failed {_userAccessor.UserId} != {uid}");

            #endregion


            var validator = new CUDOrderDetailDtoValidator(_productRepository, _userRepository);

            var validatorResult = await validator.ValidateAsync(request.CUDOrderDetailDto);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var order = await _orderRepository.GetOrderActiveByUserId(request.CUDOrderDetailDto.UserId);
            if (order == null)
            {
                order = new Order()
                {
                    OrderUniqId = _codeGenerate.GenerateGUID(),
                    IsFinally = false,
                    UserId = request.CUDOrderDetailDto.UserId,
                };
                order = await _orderRepository.Add(order);
            }

            var orderDetail = await _orderDetailRepository.GetOrderDetailByOrderIdANDProductId(order.Id, request.CUDOrderDetailDto.ProductId);

            var product = await _productRepository.Get(request.CUDOrderDetailDto.ProductId);

            int orderDetailPrice = _computationsMath.Operation(ComputationsMathEnum.Multiplied, product.Price, request.CUDOrderDetailDto.Count);

            if (orderDetail == null)
            {
                if (request.CUDOrderDetailDto.Count > 0)
                {
                    orderDetail = _mapper.Map<OrderDetail>(request.CUDOrderDetailDto);

                    orderDetail.OrderId = order.Id;

                    orderDetail.Price = orderDetailPrice;

                    await _orderDetailRepository.Add(orderDetail);

                }
            }
            else
            {
                if (request.CUDOrderDetailDto.Count == 0)
                    await _orderDetailRepository.Delete(orderDetail);
                else
                {
                    orderDetail = _mapper.Map(request.CUDOrderDetailDto, orderDetail);

                    orderDetail.Price = orderDetailPrice;

                    await _orderDetailRepository.Update(orderDetail);
                }

            }
            await _orderRepository.ChangeOrderSum(order);
            return Unit.Value;
        }
    }
}
