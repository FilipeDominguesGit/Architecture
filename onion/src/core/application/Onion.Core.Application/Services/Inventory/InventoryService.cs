using System.Collections.Generic;
using System.Linq;
using Onion.Core.Application.Extensions;
using Onion.Core.Application.Services.Inventory.Responses;
using Onion.Core.Domain.Repositories;

namespace Onion.Core.Application.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public ServiceResponse<IEnumerable<InventoryResponse>> GetInventory()
        {
            var inventory = _inventoryRepository.GetAll();

            return new ServiceResponse<IEnumerable<InventoryResponse>>()
            {
                IsSuccess = true,
                Result = inventory.MapToResponse()
            };
        }
    }
}