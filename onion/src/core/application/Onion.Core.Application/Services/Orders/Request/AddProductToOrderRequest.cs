namespace Onion.Core.Application.Services.Orders.Request
{
    public class AddProductToOrderRequest
    {
        public int OrderId { get; private set; }
        public int UserId { get; private set; }
        public int ProductId { get; private set; }

        public AddProductToOrderRequest(int orderId, int userId, int productId)
        {
            OrderId = orderId;
            UserId = userId;
            ProductId = productId;
        }


    }
}