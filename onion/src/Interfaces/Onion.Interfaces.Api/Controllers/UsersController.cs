using Microsoft.AspNetCore.Mvc;
using Onion.Core.Application.Services.Users;
using Onion.Core.Application.Services.Users.Requests;
using Onion.Interfaces.Api.Models;

namespace Onion.Interfaces.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usersService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var users = _usersService.GetUser(userId);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserViewModel request)
        {
            var response = _usersService.CreateNewUser(new CreateNewUserRequest(request.FirstName, request.LastName));

            if(response.IsSuccess)
                return Ok();
            return BadRequest();
        }
    }
}