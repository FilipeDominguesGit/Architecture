using System.Collections.Generic;
using System.Linq;
using Onion.Core.Application.Extensions;
using Onion.Core.Application.Interfaces;
using Onion.Core.Application.Services.Orders.Request;
using Onion.Core.Application.Services.Orders.Response;
using Onion.Core.Domain.Exceptions;
using Onion.Core.Domain.Repositories;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Services;

namespace Onion.Core.Application.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IProductsRepository _productRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IOrdersDomainService _orderDomainService;
        private readonly IStockDispatcher _stockDispatcher;

        public OrdersService(
            IOrdersRepository orderRepository,
            IProductsRepository productRepository,
            IUsersRepository userRepository,
            IOrdersDomainService orderDomainService,
            IStockDispatcher stockDispatcher)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderDomainService = orderDomainService;
            _stockDispatcher = stockDispatcher;
        }

        public ServiceResponse<OrderResponse> AddProductToOrder(AddProductToOrderRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);
            if (order == null)
            {
                var user = _userRepository.GetById(request.UserId);
                order = new Order(user);
            }
            var product = _productRepository.GetById(request.ProductId);

            if (product == null)
            {
                return new ServiceResponse<OrderResponse>();
            }

            try
            {
                _orderDomainService.AddProductToOrder(product, order);
            }
            catch (OutOfStockException exc)
            {
                _stockDispatcher.SendNotification(exc.Message);
                return new ServiceResponse<OrderResponse>()
                {
                    IsSuccess = false,
                    Result = order.MapToResponse()
                };
            }

            return new ServiceResponse<OrderResponse>()
            {
                IsSuccess = true,
                Result = order.MapToResponse()
            };
        }

        public ServiceResponse<IEnumerable<OrderResponse>> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();

            return new ServiceResponse<IEnumerable<OrderResponse>>()
            {
                IsSuccess = true,
                Result = orders?.MapToResponse()
            };
        }

        public ServiceResponse<OrderResponse> GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order != null)
            {
                return new ServiceResponse<OrderResponse>()
                {
                    IsSuccess = true,
                    Result = order.MapToResponse()
                };
            }

            return new ServiceResponse<OrderResponse>();
        }
    }
}
