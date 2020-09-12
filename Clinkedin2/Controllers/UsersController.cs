using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Clinkedin2.DataAccess;
using Clinkedin2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinkedin2.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersRepository _repo;

        public UsersController()
        {
            _repo = new UsersRepository();
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var allUsers = _repo.GetAllUsers();

            return Ok(allUsers);
        }


    }
}
