using System.Linq;
using Onion.Core.Application.Services.Orders.Request;
using Onion.Core.Application.Services.Orders.Response;
using Onion.Core.Domain.Repositories;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Services;

namespace Onion.Core.Application.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IOrdersDomainService _orderDomainService;

        public OrdersService(IOrdersRepository orderRepository, 
            IProductRepository productRepository,
            IUsersRepository userRepository,
            IOrdersDomainService orderDomainService)
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

        public GetAllOrdersResponse GetAllOrders()
        {
            var orders =_orderRepository.GetAll();

            return new GetAllOrdersResponse(
                orders.Select(o=>
                    new OrderResponse(
                        o.OrderNumber,
                        o.User.FullName,
                        o.User.Id,
                        o.Products.Select(p=>new OrderProductResponse(p.Id,p.Name,p.Brand,p.Price,p.Code)).ToList())
                ).ToList()
                );
        }
    }
}
