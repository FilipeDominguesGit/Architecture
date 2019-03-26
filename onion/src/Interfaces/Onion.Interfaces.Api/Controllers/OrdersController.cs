using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Onion.Core.Application.Services.Orders;
using Onion.Core.Application.Services.Orders.Request;
using Onion.Interfaces.Api.Extensions;
using Onion.Interfaces.Api.Models;
using Onion.Interfaces.Api.Models.Requests;
using Onion.Interfaces.Api.Models.Responses;

namespace Onion.Interfaces.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IOrdersService _ordersService;

        public OrdersController(LinkGenerator linkGenerator, IOrdersService ordersService)
        {
            _linkGenerator = linkGenerator;
            _ordersService = ordersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var response = _ordersService.GetAllOrders();

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var orders = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> Get(int orderId)
        {
            var response = _ordersService.GetOrderById(orderId);

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var order = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Ok(order);
        }

        [HttpPut("Add")]
        public ActionResult<Order> AddProductToOrder( [FromBody]AddProductToOrder request)
        {
            var response = _ordersService.AddProductToOrder(new AddProductToOrderRequest(request.OrderId , request.UserId, request.ProductId));

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var order = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Created(order.Link, order);
        }
    }
}