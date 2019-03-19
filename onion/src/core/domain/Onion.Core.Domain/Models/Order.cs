using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.Core.Domain.Models
{
    public class Order
    {
        public Order(User user)
        {
            Products = new List<Product>();
            User = user;
        }

        public int OrderNumber { get;  set; }
        public User User { get; private set; }
        public List<Product> Products { get; private set; }
        public float Total => CalculateTotal();

        private float CalculateTotal() {
            return Products.Select(p => p.Price).Sum();
        }
    }
}
