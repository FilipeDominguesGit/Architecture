using System;
using System.Collections.Generic;
using Layered.Dal;

namespace Layered.Bll
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _usersRepository.GetAll();
        }
    }
}
