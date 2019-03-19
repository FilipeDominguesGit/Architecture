using Onion.Core.Application.Services.Orders.Request;
using Onion.Core.Application.Services.Orders.Response;

namespace Onion.Core.Application.Services.Orders
{
    public interface IOrdersService
    {
        AddProductToOrderResponse AddProductToOrder(AddProductToOrderRequest request);

        GetAllOrdersResponse GetAllOrders();
    }
}
