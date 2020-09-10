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
        UsersRepository _inmatesRepo;

        public InmatesController()
        {
            _inmatesRepo = new UsersRepository();
        }

        [HttpPost]
        public IActionResult CreateInmate(Inmate newInmate)
        {
            
            var repo = new UsersRepository();
            repo.AddInmate(newInmate);

            return Created($"/api/inmates/{newInmate.Id}", newInmate);
        }
        
        [HttpGet]
        public IActionResult GetAllInmates()
        {
            var allInmates = _inmatesRepo.GetInmates();

            return Ok(allInmates);
        }

    }
}
