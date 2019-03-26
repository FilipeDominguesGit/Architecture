using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layered.Bll;
using Layered.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Layered.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _usersService.GetAll();
            return Ok(users);
        }
    }
}