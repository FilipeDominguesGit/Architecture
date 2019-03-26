using System.Collections.Generic;
using System.Linq;

namespace Onion.Interfaces.Api.Models.Responses
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string UserFullName { get; set; }
        public int UserId { get; set; }
        public List<BasicProduct> Products { get; set; }
        public float Total { get; set; }
        public string Link { get; set; }
    }
}