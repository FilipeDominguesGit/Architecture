using System.Linq;
using Onion.Core.Application.Services.Users.Requests;
using Onion.Core.Application.Services.Users.Responses;
using Onion.Core.Domain.Models;
using Onion.Core.Domain.Repositories;

namespace Onion.Core.Application.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;

        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GetAllUsersResponse GetAllUsers()
        {
            var users = _userRepository.GetAll();

            var response = new GetAllUsersResponse()
            {
                Users = users.Select(u=>new UserResponse(u.Id,u.FullName)).ToList()
            };

            return response;
        }

        public GetUserResponse GetUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            
            return user == null ? new GetUserResponse() : new GetUserResponse( new UserResponse(user.Id,user.FullName));
        }

        public CreateNewUserResponse CreateNewUser(CreateNewUserRequest request)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _userRepository.Save(user);

            return new CreateNewUserResponse()
            {
                IsSuccess = true
            };
        }
    }
}