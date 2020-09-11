using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clinkedin2.DataAccess;
using Clinkedin2.Models;
using Clinkedin2.Model;

namespace Clinkedin2.Controllers
{
    [Route("api/inmates")]
    [ApiController]
    public class InmatesController : ControllerBase
    {
        static UsersRepository _inmatesRepo;

        static InmatesController()
        {
            _inmatesRepo = new UsersRepository();

            var inmatePiper = new Inmate { Id = 1, Age = 30, FirstName = "Piper", LastName = "Chapman", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), UserRole = UserRole.Inmate };
            var inmateClaudette = new Inmate { Id = 2, Age = 50, FirstName = "Claudette", LastName = "Pelage", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<Inmate>() { inmatePiper }, Enemies = new List<Inmate>(), UserRole = UserRole.Inmate };
            var inmateGalina = new Inmate { Id = 3, Age = 55, FirstName = "Galina", LastName = "Reznikov", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<Inmate>() { inmateClaudette, inmatePiper }, Enemies = new List<Inmate>(), UserRole = UserRole.Inmate };
            var inmateJane = new Inmate { Id = 4, Age = 25, FirstName = "Jane", LastName = "Miller", Gender = Gender.Female, PrisonFacility = "Tennessee Prison for Women", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), UserRole = UserRole.Inmate };
            var inmateDahlia = new Inmate { Id = 5, Age = 42, FirstName = "Dahlia", LastName = "McLeary", Gender = Gender.Female, PrisonFacility = "Tennessee Prison for Women", Friends = new List<Inmate>() { inmateJane }, Enemies = new List<Inmate>(), UserRole = UserRole.Inmate };

            _inmatesRepo.AddInmate(inmateDahlia);
            _inmatesRepo.AddInmate(inmateJane);
            _inmatesRepo.AddInmate(inmateGalina);
            _inmatesRepo.AddInmate(inmateClaudette);
            _inmatesRepo.AddInmate(inmatePiper);

        }

        [HttpPost]
        public IActionResult CreateInmate(Inmate newInmate)
        {
            
            var repo = new UsersRepository();
            repo.AddInmate(newInmate);

            return Created($"/api/inmates/{newInmate.Id}", newInmate);
        }

        //[HttpGet] //ANCA: Commenting this out for now since I don't know if it is ok to have 2 GET methods in the same Controller?!
        //public IActionResult GetAllInmates(UserRole userRole)
        //{
        //    var allInmates = _inmatesRepo.GetInmates(UserRole.Inmate);

        //    return Ok(allInmates);
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateInmate(int id, User inmate)
        {
            var updatedInmateRecord = _inmatesRepo.Update(id, inmate);

            return Ok(updatedInmateRecord);
         }


        [HttpGet("{id}")]
        public IActionResult GetFriends(int id)
        {
            var myFriends = _inmatesRepo.GetMyFriends(id);

            return Ok(myFriends);
        }
    }
}
