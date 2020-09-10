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
        //UsersRepository _repo;

        //public UsersController()
        //{
        //    _repo = new UsersRepository();
        //}

        [HttpPost]
        public IActionResult CreateInmate( User newInmate)
        {
            //var newInmate = new User { FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, PrisonFacility = user.PrisonFacility, DateOfBirth = user.DateOfBirth, UserRole = UserRole.Inmate };
            //newInmate.Id = _repo.Select(user => user.Id).Max() + 1;
            var repo = new UsersRepository();
            repo.AddInmate(newInmate);

            return Created($"/api/users/{newInmate.Id}", newInmate);
        }

        [HttpGet]
        public IActionResult GetAllInmates()
        {
            var repo = new UsersRepository();
            var allInmates = repo.GetInmates();

            return Ok(allInmates);
        }

    }
}
