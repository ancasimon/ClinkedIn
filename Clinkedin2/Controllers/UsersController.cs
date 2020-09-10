using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Clinkedin2.DataAccess;
using Clinkedin2.Model;
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

        //ANCA: I was going to delete this from here but then thought that maybe we would want to have an admin who could create users??
        //Ideally only that individual (inmate or warden) could create their record - but maybe they need an admin to help them get it started??...
        //[HttpPost]
        //public IActionResult CreateUser(User newUser)
        //{
            
        //    _repo.AddUser(newUser);

        //    return Created($"/api/users/{newUser.Id}", newUser);
        //}

      

        [HttpGet]
        public IActionResult GetUsers()
        {
            var allUsers = _repo.GetAllUsers();

            return Ok(allUsers);
        }

    }
}
