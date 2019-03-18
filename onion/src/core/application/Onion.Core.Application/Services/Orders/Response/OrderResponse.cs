using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.Core.Application.Services.Orders.Response
{
    public class OrderResponse
    {
        public OrderResponse(Guid orderNumber, string userFullName, int userId, List<OrderProductResponse> orders)
        {
            OrderNumber = orderNumber;
            UserFullName = userFullName;
            UserId = userId;
            Orders = orders;
            Total = Orders.Select(o => o.Price).Sum();
        }

        public Guid OrderNumber { get; private set; }
        public string UserFullName { get; private set; }
        public int UserId { get; private set; }
        public  List<OrderProductResponse> Orders { get; private set; }
        public float Total { get; set; }

    }
}
