using System.Collections.Generic;
using System.Linq;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;

namespace Onion.Infrastructure.Repositories.MongoDb
{
    public class OrdersRepository :IOrdersRepository
    {
        private readonly List<Order> _inMemoryOrdersDb;
        private static int _lastId;

        public OrdersRepository()
        {
            _lastId = 0;
            _inMemoryOrdersDb = new List<Order>()
            {
               new Order(
                   new User()
                   {
                       FirstName = "User A",
                       LastName = "Last Name A",
                       Id = ++_lastId
                   })
               {
                   OrderNumber = ++_lastId,
                   Products =
                   {
                       new Product()
                       {
                           Id = 1,
                           Brand = "Brand A",
                           Category = "Category A",
                           Name = "Name A",
                           Price = 100

                       },
                       new Product()
                       {
                           Id = 2,
                           Brand = "Brand B",
                           Category = "Category B",
                           Name = "Name B",
                           Price = 150

                       }
                   }
               } 
                
            };

        }
        public IEnumerable<Order> GetAll()
        {
            return _inMemoryOrdersDb;
        }

        public Order GetById(int id)
        {
            return _inMemoryOrdersDb.FirstOrDefault(o => o.OrderNumber == id);
        }

        public void Save(Order entity)
        {
            entity.OrderNumber = ++_lastId;
            _inMemoryOrdersDb.Add(entity);
        }

        public void Delete(Order entity)
        {
            var user = _inMemoryOrdersDb.FirstOrDefault(o => o.OrderNumber == entity.OrderNumber);

            if (user != null)
                _inMemoryOrdersDb.Remove(user);
        }

        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return _inMemoryOrdersDb.Where(o => o.User.Id == userId);
        }
    }
}