using System.Collections.Generic;
using Onion.Core.Application.Services.Inventory.Responses;

namespace Onion.Core.Application.Services.Inventory
{
    public interface IInventoryService
    {
        ServiceResponse<IEnumerable<InventoryResponse>> GetInventory();

    }
}