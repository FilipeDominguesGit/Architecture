using System.Linq;
using Onion.Core.Application.Services.Orders.Request;
using Onion.Core.Application.Services.Orders.Response;
using Onion.Core.Domain.Repositories;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Services;

namespace Onion.Core.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderDomainService _orderDomainService;

        public OrderService(IOrderRepository orderRepository, 
            IProductRepository productRepository,
            IUserRepository userRepository,
            IOrderDomainService orderDomainService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderDomainService = orderDomainService;
        }

        public AddProductToOrderResponse AddProductToOrder(AddProductToOrderRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);
            if (order == null)
            {
                var user = _userRepository.GetById(request.UserId);
                order = new Order(user);
            }
            var product = _productRepository.GetById(request.ProductId);
            
            _orderDomainService.AddProductToOrder(product,order);

            var orderProductsResponse = order.Products
                .OrderBy(v=>v.Id)
                .Select(p => new OrderProductResponse(p.Id, p.Name, p.Brand, p.Price, p.Code)).ToList();

            var orderResponse = new OrderResponse(order.OrderNumber, order.User.FullName,order.User.Id, orderProductsResponse);

            return new AddProductToOrderResponse(orderResponse);
        }
    }
}
