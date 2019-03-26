using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Application.Services.Products.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Code { get; set; }
    }
}
