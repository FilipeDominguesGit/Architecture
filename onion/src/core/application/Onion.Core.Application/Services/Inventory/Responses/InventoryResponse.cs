using Onion.Core.Application.Services.Products.Responses;

namespace Onion.Core.Application.Services.Inventory.Responses
{
    public class InventoryResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
}