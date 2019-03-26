using System.Collections.Generic;
using System.Linq;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;

namespace Onion.Infrastructure.Repositories.MongoDb
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly List<Product> _inMemoryDb;
        private static int _lastId;

        public ProductsRepository()
        {
            _inMemoryDb = new List<Product>()
            {
                new Product()
                {
                    Id = ++_lastId,
                    Brand = "Brand A",
                    Category = "Category A",
                    Name = "Name A",
                    Price = 100

                },
                new Product()
                {
                    Id = ++_lastId,
                    Brand = "Brand B",
                    Category = "Category B",
                    Name = "Name B",
                    Price = 150

                }
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _inMemoryDb;
        }

        public Product GetById(int id)
        {
            return _inMemoryDb.FirstOrDefault(p => p.Id == id);
        }

        public void Save(Product entity)
        {
            entity.Id = ++_lastId;
            _inMemoryDb.Add(entity);
        }

    }
}