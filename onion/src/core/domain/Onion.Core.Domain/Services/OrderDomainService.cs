using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;
using System;
using Onion.Core.Domain.Exceptions;

namespace Onion.Core.Domain.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderDomainService(IInventoryRepository inventoryRepository, IOrderRepository orderRepository)
        {
            _inventoryRepository = inventoryRepository;
            _orderRepository = orderRepository;
        }

        public void AddProductToOrder(Product product, Order order)
        {
            var inventoryItem = _inventoryRepository.GetById(product.Id);

            if (inventoryItem.Quantity > 0)
            {
                inventoryItem.Quantity--;
                order.Products.Add(product);

                _inventoryRepository.Save(inventoryItem);
                _orderRepository.Save(order);
            }
            else
            {
                throw new OutOfStockException();
            }
        }
    }
}
