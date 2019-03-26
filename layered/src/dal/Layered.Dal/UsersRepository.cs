using System;
using System.Collections.Generic;

namespace Layered.Dal
{
    public class UsersRepository
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
                    FirstName = "User B",
                    LastName = "Last Name B",
                    Id = ++_lastId
                }
            };
        }

        public IEnumerable<User> GetAll()
        {
           return _inMemoryUsersDb;
        }
    }
}
