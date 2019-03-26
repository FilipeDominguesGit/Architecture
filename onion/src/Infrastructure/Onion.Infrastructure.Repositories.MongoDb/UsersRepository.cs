using System;
using System.Collections.Generic;
using System.Linq;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;

namespace Onion.Infrastructure.Repositories.MongoDb
{
    public class UsersRepository : IUsersRepository
    {
        private readonly List<User> _inMemoryUsersDb;
        private static int _lastId;

        public UsersRepository()
        {
            _lastId = 0;

            _inMemoryUsersDb = new List<User>()
            {
                new User()
                {
                    FirstName = "User A",
                    LastName = "Last Name A",
                    Id = ++_lastId
                },
                new User()
                {
                    FirstName = "User B",
                    LastName = "Last Name B",
                    Id = ++_lastId
                },
                new User()
                {
                    FirstName = "User C",
                    LastName = "Last Name C",
                    Id = ++_lastId
                }
            };
        }

        public IEnumerable<User> GetAll()
        {
            return _inMemoryUsersDb;
        }

        public User GetById(int id)
        {
            return _inMemoryUsersDb.FirstOrDefault(u => u.Id == id);
        }

        public void Save(User entity)
        {
            entity.Id = ++_lastId;
            _inMemoryUsersDb.Add(entity);
        }

    }
}
