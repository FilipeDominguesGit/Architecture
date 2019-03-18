using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.Core.Domain.Models
{
    public class Order
    {
        public Order(User user)
        {
            OrderNumber = Guid.NewGuid();
            Products = new List<Product>();
            User = user;
        }

        public Guid OrderNumber { get; private set; }
        public User User { get; private set; }
        public List<Product> Products { get; private set; }
        public float Total => CalculateTotal();

        private float CalculateTotal() {
            return Products.Select(p => p.Price).Sum();
        }
    }
}
