using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clinkedin2.DataAccess;
using Clinkedin2.Models;

namespace Clinkedin2.Controllers
{
    [Route("api/wardens")]
    [ApiController]
    public class WardensController : ControllerBase
    {
        UsersRepository _repo;

        public WardensController()
        {
            _repo = new UsersRepository();
        }

        [HttpPost]
        public IActionResult CreateWarden(Warden newWarden)
        {

            _repo.AddWarden(newWarden);

            return Created($"/api/wardens/{newWarden.Id}", newWarden);
        }

        [HttpGet]
        public IActionResult GetAllInmates(UserRole userRole)
        {
            var allInmates = _repo.GetInmates(UserRole.Inmate);

            return Ok(allInmates);
        }

        
    }
}
