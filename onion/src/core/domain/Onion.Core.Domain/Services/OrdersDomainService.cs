using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;
using System;
using Onion.Core.Domain.Exceptions;

namespace Onion.Core.Domain.Services
{
    public class OrdersDomainService : IOrdersDomainService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IOrdersRepository _orderRepository;

        public OrdersDomainService(IInventoryRepository inventoryRepository, IOrdersRepository orderRepository)
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
