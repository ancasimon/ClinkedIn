﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clinkedin2.DataAccess;
using Clinkedin2.Models;

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

            var inmatePiper = new Inmate { Id = 1, Age = 30, FirstName = "Piper", LastName = "Chapman", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<User>(), Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2015, 09, 20), SentenceEndDate = new DateTime(2020, 09, 20), Interest = "Sports" };
            var inmateClaudette = new Inmate { Id = 2, Age = 50, FirstName = "Claudette", LastName = "Pelage", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<User>() { inmatePiper }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2020, 01, 01), SentenceEndDate = new DateTime(2020, 12, 31), Interest = "Music" };
            var inmateGalina = new Inmate { Id = 3, Age = 55, FirstName = "Galina", LastName = "Reznikov", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<User>() { inmateClaudette, inmatePiper }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2019, 01, 01), SentenceEndDate = new DateTime(2021, 12, 31), Interest = "Reading" };
            var inmateJane = new Inmate { Id = 4, Age = 25, FirstName = "Jane", LastName = "Miller", Gender = Gender.Female, PrisonFacility = "Tennessee Prison for Women", Friends = new List<User>(), Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2020, 09, 01), SentenceEndDate = new DateTime(2020, 09, 30), Interest = "Cars" };
            var inmateDahlia = new Inmate { Id = 5, Age = 42, FirstName = "Dahlia", LastName = "McLeary", Gender = Gender.Female, PrisonFacility = "Tennessee Prison for Women", Friends = new List<User>() { inmateJane }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2020, 08, 20), SentenceEndDate = new DateTime(2020, 09, 20), Interest = "Sports" };


            _inmatesRepo.AddInmate(inmateDahlia);
            _inmatesRepo.AddInmate(inmateJane);
            _inmatesRepo.AddInmate(inmateGalina);
            _inmatesRepo.AddInmate(inmateClaudette);
            _inmatesRepo.AddInmate(inmatePiper);

        }

        [HttpPost]
        public IActionResult CreateInmate(Inmate newInmate)
        {

            _inmatesRepo.AddInmate(newInmate);

            return Created($"/api/inmates/{newInmate.Id}", newInmate);
        }

        //api/inmates/1/friends/5
        [HttpPost("{id}/friends/{newFriendId}")]
        public IActionResult AddFriend(int id, int newFriendId)
        {
            var selectedInmate = _inmatesRepo.GetById(id);
            var newFriend = _inmatesRepo.GetById(newFriendId);
            selectedInmate.Friends.Add(newFriend);

            return Ok($"{selectedInmate.FirstName} now has a new friend ({newFriend.FirstName} {newFriend.LastName})!");

        }

        public IActionResult GetAllInmates()
        {
            var allInmates = _inmatesRepo.GetInmates();

            return Ok(allInmates);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInmate(int id, User inmate)
        {
            var updatedInmateRecord = _inmatesRepo.Update(id, inmate);

            return Ok(updatedInmateRecord);
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var selectedUser = _inmatesRepo.GetById(id);

            return Ok(selectedUser);
        }

        [HttpGet("{id}/days")]
        public IActionResult CalculateDays(int id)
        {
            var selectedUser = _inmatesRepo.GetById(id);
            var inmateClassRecord = (Inmate)Convert.ChangeType(selectedUser, typeof(Inmate));


            var completedDays = _inmatesRepo.CalculateCompletedSentenceDays(id);
            var remainingDays = _inmatesRepo.CalculateRemainingSentenceDays(id);

            return Ok(@$"{inmateClassRecord.FirstName} {inmateClassRecord.LastName} has completed {completedDays} days of her penance.
Her countdown began on {inmateClassRecord.SentenceStartDate}.
Her final day in the clink will be on {inmateClassRecord.SentenceEndDate}.
She has {remainingDays} days to go!!!");
        }

            //Monique added Enemy search 
            [HttpPost("{id}/enemies/{newEnemiesId}")]
            public IActionResult AddEnemies(int id, int newEnemiesId)
            {
                var selectedInmate = _inmatesRepo.GetById(id);
                var newEnemies = _inmatesRepo.GetById(newEnemiesId);
                selectedInmate.Enemies.Add(newEnemies);

                return Ok($"{selectedInmate.FirstName} now has a new enemy ({newEnemies.FirstName} {newEnemies.LastName})!");

            }
        }
    }
