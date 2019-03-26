using System.Collections.Generic;
using Onion.Core.Application.Services.Users.Requests;
using Onion.Core.Application.Services.Users.Responses;

namespace Onion.Core.Application.Services.Users
{
    public interface IUsersService
    {
        ServiceResponse<IEnumerable<UserResponse>> GetAllUsers();
        ServiceResponse<UserResponse> GetUser(int userId);
        ServiceResponse<UserResponse> CreateNewUser(CreateNewUserRequest request);
    }
}