using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Onion.Core.Application.Services.Inventory;
using Onion.Interfaces.Api.Extensions;
using Onion.Interfaces.Api.Models.Responses;

namespace Onion.Interfaces.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly LinkGenerator _linkGenerator;

        public InventoryController(IInventoryService inventoryService, LinkGenerator linkGenerator)
        {
            _inventoryService = inventoryService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Inventory>> Get()
        {
            var response = _inventoryService.GetInventory();

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var inventory = response.Result.MapToResponse(_linkGenerator, HttpContext);
        
            return Ok(inventory);
        }
    }
}