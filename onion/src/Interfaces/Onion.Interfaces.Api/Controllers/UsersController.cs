using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Onion.Core.Application.Services.Users;
using Onion.Core.Application.Services.Users.Requests;
using Onion.Interfaces.Api.Extensions;
using Onion.Interfaces.Api.Models.Requests;
using Onion.Interfaces.Api.Models.Responses;

namespace Onion.Interfaces.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IUsersService _usersService;

        public UsersController(LinkGenerator linkGenerator, IUsersService usersService)
        {
            _linkGenerator = linkGenerator;
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var response = _usersService.GetAllUsers();

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var users = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<User> Get(int userId)
        {
            var response = _usersService.GetUser(userId);

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var user = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(CreateUser request)
        {
            var response = _usersService.CreateNewUser(new CreateNewUserRequest(request.FirstName, request.LastName));

            if (!response.IsSuccess)
            {
                BadRequest();
            }

            var user = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Created(user.Link,user);
        }
    }
}