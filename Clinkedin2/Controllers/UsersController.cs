using System;
using System.Collections.Generic;
using System.Linq;
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
        UserRepository _repo;

        public UsersController()
        {
            _repo = new UserRepository();
        }

        [HttpPost]
        public IActionResult CreateInmate( Inmate newInmate)
        {
            //var newInmate = new User { FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, PrisonFacility = user.PrisonFacility, DateOfBirth = user.DateOfBirth, UserRole = UserRole.Inmate };
            //newInmate.Id = _repo.Select(user => user.Id).Max() + 1;
            _repo.Add(newInmate);

            return Created($"/api/users/{newInmate.Id}", newInmate);
        }
        [HttpGet]
        public IActionResult GetAllInmates()
        {
            var allInmates = _repo.GetInmates();

            return Ok(allInmates);
        }

    }
}
