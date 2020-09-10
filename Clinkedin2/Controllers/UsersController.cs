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

        [HttpPost]
        public IActionResult CreateUser(User newUser)
        {
            
            _repo.AddUser(newUser);

            return Created($"/api/users/{newUser.Id}", newUser);
        }

        //ANCA: I will delete info below if we cannot have the 2 separate calls in the same Controller - will ask on Saturday!
        //[HttpPost]
        //public IActionResult CreateInmate(Inmate newInmate)
        //{
        //    //Anca: line below left over from trying to have separate classes for Inmate and User - will delete if we cannot do that.
        //    //var newInmate = new User { FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, PrisonFacility = user.PrisonFacility, DateOfBirth = user.DateOfBirth, UserRole = UserRole.Inmate };
        //    if (newInmate.UserRole == UserRole.Inmate)
        //    {
        //        var repo = new UsersRepository();
        //        repo.AddInmate(newInmate);

        //        return Created($"/api/users/{newInmate.Id}", newInmate);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public IActionResult CreateWarden(Warden newWarden)
        //{
        //    if (newWarden.UserRole == UserRole.Warden)
        //    {
        //        var repo = new UsersRepository();
        //        repo.AddWarden(newWarden);

        //        return Created($"/api/users/{newWarden.Id}", newWarden);
        //    }
        //    return NotFound();
        //}

        //ANCA: Currently, we have only 1 GET request for inmates only - if we wnat to get all uses (including wardens), we will have the same issue as with the 2 post methods ...
        //We coudl create a separate WardensRepository ... is that the answer?
        [HttpGet]
        public IActionResult GetAllInmates()
        {
            var allInmates = _repo.GetInmates();

            return Ok(allInmates);
        }

    }
}
