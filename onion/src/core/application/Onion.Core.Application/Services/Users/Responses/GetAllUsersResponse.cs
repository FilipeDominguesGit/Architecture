using System.Collections.Generic;

namespace Onion.Core.Application.Services.Users.Responses
{
    public class GetAllUsersResponse
    {
        public GetAllUsersResponse(List<UserResponse> users)
        {
            Users = users;
        }

        public GetAllUsersResponse()
        {
            Users = new List<UserResponse>();
        }

        public List<UserResponse> Users { get; set; }
    }
}