using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.Core.Domain.Models
{
    public class Order
    {
        public Guid OrderNumber { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public float Total => CalculateTotal();

        private float CalculateTotal() {
            return Products.Select(p => p.Price).Sum();
        }
    }
}
