using System.Collections.Generic;
using System.Linq;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;

namespace Onion.Infrastructure.Repositories.Sql
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<Inventory> _inMemoryDb;

        public InventoryRepository()
        {
            _inMemoryDb = new List<Inventory>()
            {
                new Inventory()
                {
                    Product =  new Product()
                    {
                        Id = 1,
                        Brand = "Brand A",
                        Category = "Category A",
                        Name = "Name A",
                        Price = 100

                    },
                    Quantity = 2
                },
                new Inventory()
                {
                    Product = new Product()
                    {
                        Id = 2,
                        Brand = "Brand B",
                        Category = "Category B",
                        Name = "Name B",
                        Price = 150

                     },
                    Quantity = 1

                }
            };
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _inMemoryDb;
        }

        public Inventory GetById(int id)
        {
            return _inMemoryDb.FirstOrDefault(i => i.Product.Id == id);
        }

        public void Save(Inventory entity)
        {
            _inMemoryDb.Add(entity);
        }

    }
}