namespace Onion.Core.Application.Services.Users.Responses
{
    public class UserResponse
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }

        public UserResponse(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

    }
}