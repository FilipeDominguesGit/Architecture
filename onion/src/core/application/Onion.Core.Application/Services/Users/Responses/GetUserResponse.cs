namespace Onion.Core.Application.Services.Users.Responses
{
    public class GetUserResponse
    {
        public UserResponse User { get; private set; }
        public bool IsSuccess => User != null;

        public GetUserResponse()
        {
        }

        public GetUserResponse(UserResponse user)
        {
            User = user;
            }
    }
}