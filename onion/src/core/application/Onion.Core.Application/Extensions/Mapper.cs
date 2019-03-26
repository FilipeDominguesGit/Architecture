using System.Collections.Generic;
using System.Linq;
using Onion.Core.Application.Services.Inventory.Responses;
using Onion.Core.Application.Services.Orders.Response;
using Onion.Core.Application.Services.Products.Responses;
using Onion.Core.Application.Services.Users.Responses;
using Onion.Core.Domain.Models;

namespace Onion.Core.Application.Extensions
{
    public static class Mapper
    {
        public static IEnumerable<InventoryResponse> MapToResponse(this IEnumerable<Inventory> inventoryResponses)
        {
            return inventoryResponses.Select(i => new InventoryResponse()
            {
                ProductId = i.Product.Id,
                Brand = i.Product.Brand,
                Name = i.Product.Name,
                Code = i.Product.Code,
                Quantity = i.Quantity,
                Category = i.Product.Category
            });
        }

        public static OrderResponse MapToResponse(this Order order)
        {
            return new OrderResponse()
            {
                OrderNumber = order.OrderNumber,
                UserFullName = order.User.FullName,
                UserId = order.User.Id,
                Products = order.Products.Select(p => new OrderProductResponse()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price,
                }).ToList(),
                
            };
        }

        public static IEnumerable<OrderResponse> MapToResponse(this IEnumerable<Order> orders)
        {
            return orders.Select(o => o.MapToResponse());
        }

        public static ProductResponse MapToResponse(this Product product)
        {
            return new ProductResponse()
            {
                Id = product.Id,
                Brand = product.Brand,
                Name = product.Name,
                Code = product.Code,
                Price = product.Price,
                Category = product.Category,
                
            };
        }

        public static IEnumerable<ProductResponse> MapToResponse(this IEnumerable<Product> productResponses)
        {
            return productResponses.Select(o => o.MapToResponse());
        }

        public static UserResponse MapToResponse(this User user)
        {
            return new UserResponse(user.Id, user.FullName);
        }

        public static IEnumerable<UserResponse> MapToResponse(this IEnumerable<User> productResponses)
        {
            return productResponses.Select(o => o.MapToResponse());
        }
    }
}