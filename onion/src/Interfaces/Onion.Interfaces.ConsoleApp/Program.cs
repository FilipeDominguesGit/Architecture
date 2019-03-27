using System;
using System.Linq;
using Onion.Core.Application.Services.Users;
using Onion.Infrastructure.Repositories.MongoDb;

namespace Onion.Interfaces.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UsersService(new UsersRepository());

            var results = userService.GetAllUsers();

            results
                .Result
                .ToList()
                .ForEach(userResponse => 
                    Console.WriteLine($"{userResponse.Id} - {userResponse.FullName}")
                    );
        }
    }
}
