using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Onion.Core.Application.Services.Inventory.Responses;
using Onion.Core.Application.Services.Orders.Response;
using Onion.Core.Application.Services.Products.Responses;
using Onion.Core.Application.Services.Users.Responses;
using Onion.Interfaces.Api.Models.Responses;

namespace Onion.Interfaces.Api.Extensions
{
    public static class Mapper
    {

        public static IEnumerable<Inventory> MapToResponse(this IEnumerable<InventoryResponse> inventoryResponses, LinkGenerator linkGenerator, HttpContext context)
        {
            return inventoryResponses.Select(i => new Inventory()
            {
                Id = i.ProductId,
                Brand = i.Brand,
                Name = i.Name,
                Code = i.Code,
                Quantity = i.Quantity,
                Link = linkGenerator.GetPathByAction(context, "Get", "Products",
                    new { productId = i.ProductId })
            });
        }

        public static Order MapToResponse(this OrderResponse orderResponse, LinkGenerator linkGenerator, HttpContext context)
        {
            return new Order()
            {
                OrderNumber = orderResponse.OrderNumber,
                Total = orderResponse.Total,
                UserFullName = orderResponse.UserFullName,
                UserId = orderResponse.UserId,
                Products = orderResponse.Products.Select(p => new BasicProduct()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price,
                    Link = linkGenerator.GetPathByAction(context, "Get", "Products", new { productId = p.Id })
                }).ToList(),
                Link = linkGenerator.GetPathByAction(context, "Get", "Orders", new { orderId = orderResponse.OrderNumber })
            };
        }

        public static IEnumerable<Order> MapToResponse(this IEnumerable<OrderResponse> orders, LinkGenerator linkGenerator, HttpContext context)
        {
            return orders.Select(o => o.MapToResponse(linkGenerator, context));
        }

        public static Product MapToResponse(this ProductResponse productResponse, LinkGenerator linkGenerator, HttpContext context)
        {
            return new Product()
            {
                Id = productResponse.Id,
                Brand = productResponse.Brand,
                Name = productResponse.Name,
                Code = productResponse.Code,
                Price = productResponse.Price,
                Category = productResponse.Category,
                Link = linkGenerator.GetPathByAction(context, "Get", "Products", new { productId = productResponse.Id })
            };
        }

        public static IEnumerable<Product> MapToResponse(this IEnumerable<ProductResponse> productResponses, LinkGenerator linkGenerator, HttpContext context)
        {
            return productResponses.Select(o => o.MapToResponse(linkGenerator, context));
        }

        public static User MapToResponse(this UserResponse userResponse, LinkGenerator linkGenerator, HttpContext context)
        {
            return new User()
            {
                Id = userResponse.Id,
                FullName = userResponse.FullName,
                Link = linkGenerator.GetPathByAction(context, "Get", "Users", new { userId = userResponse.Id })
            };
        }

        public static IEnumerable<User> MapToResponse(this IEnumerable<UserResponse> productResponses, LinkGenerator linkGenerator, HttpContext context)
        {
            return productResponses.Select(o => o.MapToResponse(linkGenerator, context));
        }

    }
}