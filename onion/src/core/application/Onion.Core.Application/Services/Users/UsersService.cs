using System.Collections.Generic;
using System.Linq;
using Onion.Core.Application.Extensions;
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

        public ServiceResponse<IEnumerable<UserResponse>> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            var response = new ServiceResponse<IEnumerable<UserResponse>>()
            {
                Result = users.MapToResponse(),
                IsSuccess = true
            };

            return response;
        }

        public ServiceResponse<UserResponse> GetUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            
            return user == null ? new ServiceResponse<UserResponse>() : new ServiceResponse<UserResponse>()
            {
                IsSuccess = true,
                Result = user.MapToResponse()
            };
        }

        public ServiceResponse<UserResponse> CreateNewUser(CreateNewUserRequest request)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _userRepository.Save(user);

            return new ServiceResponse<UserResponse>()
            {
                Result = user.MapToResponse(),
                IsSuccess = true
            };
        }
    }
}