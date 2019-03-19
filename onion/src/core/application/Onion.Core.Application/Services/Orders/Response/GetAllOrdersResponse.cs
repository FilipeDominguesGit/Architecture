using System.Collections.Generic;

namespace Onion.Core.Application.Services.Orders.Response
{
    public class GetAllOrdersResponse
    {
        public bool IsSuccess => Orders != null;
        public List<OrderResponse> Orders { get; private set; }

        public GetAllOrdersResponse()
        {
        }

        public GetAllOrdersResponse(List<OrderResponse> orders)
        {
            Orders = orders;
        }
    }
}