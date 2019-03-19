namespace Onion.Core.Application.Services.Users.Requests
{
    public class CreateNewUserRequest
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public CreateNewUserRequest( string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}