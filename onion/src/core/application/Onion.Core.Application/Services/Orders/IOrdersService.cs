using System.Collections.Generic;
using Onion.Core.Application.Services.Orders.Request;
using Onion.Core.Application.Services.Orders.Response;

namespace Onion.Core.Application.Services.Orders
{
    public interface IOrdersService
    {
        ServiceResponse<OrderResponse> AddProductToOrder(AddProductToOrderRequest request);
        ServiceResponse<IEnumerable<OrderResponse>> GetAllOrders();
        ServiceResponse<OrderResponse> GetOrderById(int id);
    }
}
