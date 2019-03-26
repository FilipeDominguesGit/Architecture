using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;
using System;
using Onion.Core.Domain.Exceptions;

namespace Onion.Core.Domain.Services
{
    public class OrdersDomainService : IOrdersDomainService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public OrdersDomainService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public void AddProductToOrder(Product product, Order order)
        {
            var inventoryItem = _inventoryRepository.GetById(product.Id);

            if (inventoryItem.Quantity > 0)
            {
                inventoryItem.Quantity--;
                order.Products.Add(product);
            }
            else
            {
                throw new OutOfStockException($"Product {product.Id} out of stock");
            }
        }
    }
}
