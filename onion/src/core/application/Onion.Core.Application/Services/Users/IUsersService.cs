using Onion.Core.Application.Services.Users.Requests;
using Onion.Core.Application.Services.Users.Responses;

namespace Onion.Core.Application.Services.Users
{
    public interface IUsersService
    {
        GetAllUsersResponse GetAllUsers();
        GetUserResponse GetUser(int userId);
        CreateNewUserResponse CreateNewUser(CreateNewUserRequest request);
    }
}