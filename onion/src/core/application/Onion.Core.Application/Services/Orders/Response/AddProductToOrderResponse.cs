namespace Onion.Core.Application.Services.Orders.Response
{
    public class AddProductToOrderResponse
    {
        public AddProductToOrderResponse(OrderResponse order)
        {
            Order = order;
        }

        public OrderResponse Order { get; private set; }
    }
}