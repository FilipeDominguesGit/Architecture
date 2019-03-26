namespace Onion.Interfaces.Api.Models.Requests
{
    public class AddProductToOrder
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
}