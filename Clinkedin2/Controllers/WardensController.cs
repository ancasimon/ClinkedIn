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
        UsersRepository _wardensRepo;
        UsersRepository _inmatesRepo;

        public WardensController()
        {
            _inmatesRepo = new UsersRepository();
            _wardensRepo = new UsersRepository();
        }

        [HttpPost]
        public IActionResult CreateWarden(Warden newWarden)
        {

            _wardensRepo.AddWarden(newWarden);

            return Created($"/api/wardens/{newWarden.Id}", newWarden);
        }

        [HttpGet]
        public IActionResult GetAllInmates()
        {
            var allInmates = _inmatesRepo.GetInmates();

            return Ok(allInmates);
        }
    }
}
