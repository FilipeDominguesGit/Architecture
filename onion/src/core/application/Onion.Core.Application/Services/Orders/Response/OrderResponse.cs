using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.Core.Application.Services.Orders.Response
{
    public class OrderResponse
    {
        public int OrderNumber { get; set; }
        public string UserFullName { get; set; }
        public int UserId { get; set; }
        public List<OrderProductResponse> Products { get; set; }
        public float Total => Products.Select(o => o.Price).Sum();
    }
}
