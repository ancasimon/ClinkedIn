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
        
            var inmatePiper = new Inmate { Id = 1, Age = 30, FirstName = "Piper", LastName = "Chapman", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<User>(), Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2015, 09, 20), SentenceEndDate = new DateTime(2020, 09, 20), Interest = "Sports", Service = new List<string>() { "tutor", "writer" } };
            var inmateClaudette = new Inmate { Id = 2, Age = 50, FirstName = "Claudette", LastName = "Pelage", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<User>() { inmatePiper }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2020, 01, 01), SentenceEndDate = new DateTime(2020, 12, 31), Interest = "Music", Service = new List<string>() { "beautician" } };
            var inmateGalina = new Inmate { Id = 3, Age = 55, FirstName = "Galina", LastName = "Reznikov", Gender = Gender.Female, PrisonFacility = "Litchfield Penitentiary", Friends = new List<User>() { inmateClaudette, inmatePiper }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2019, 01, 01), SentenceEndDate = new DateTime(2021, 12, 31), Interest = "Reading", Service = new List<string>() { "legal", "medical" } };
            var inmateJane = new Inmate { Id = 4, Age = 25, FirstName = "Jane", LastName = "Miller", Gender = Gender.Female, PrisonFacility = "Tennessee Prison for Women", Friends = new List<User>() { inmateClaudette, inmatePiper, inmateGalina }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2020, 09, 01), SentenceEndDate = new DateTime(2020, 09, 30), Interest = "Cars", Service = new List<string>() };
            var inmateDahlia = new Inmate { Id = 5, Age = 42, FirstName = "Dahlia", LastName = "McLeary", Gender = Gender.Female, PrisonFacility = "Tennessee Prison for Women", Friends = new List<User>() { inmateJane, inmateClaudette, inmatePiper, inmateGalina }, Enemies = new List<User>(), UserRole = UserRole.Inmate, SentenceStartDate = new DateTime(2020, 08, 20), SentenceEndDate = new DateTime(2020, 09, 20), Interest = "Sports", Service = new List<string>() };


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


        //ANCA: Ability to view one's friends:
        [HttpGet("{id}/friends")]
        public IActionResult ViewFriends(int id)
        {
            var selectedInmate = _inmatesRepo.GetById(id);
            var selectedInmateFriends = _inmatesRepo.GetMyFriends(id);

            return Ok($"Here are {selectedInmate.FirstName}'s friends: {string.Join(",", selectedInmateFriends)}.");

        }

        //Anca: Ability to view your friends' friends:
        [HttpGet("{id}/friendconnections")]
        public IActionResult ViewFriendsOfFriends(int id)
        {
            var selectedInmate = _inmatesRepo.GetById(id);
            List<string> friendsOfFriends= _inmatesRepo.GetFriendsOfFriends(id);
        
            if (selectedInmate.Friends.Count == 0)
            {
                return Ok($"My name is {selectedInmate.FirstName} {selectedInmate.LastName}. Turns out I don't have any friends...");
            }
            else if(friendsOfFriends.Count == 0)
            {
                return Ok($"My name is {selectedInmate.FirstName} {selectedInmate.LastName}. My current friends have no other friends! What does that say about me?? ...");

            }

            return Ok($"My name is {selectedInmate.FirstName} {selectedInmate.LastName} and here are all my friends' friends: {string.Join(",", friendsOfFriends)}.");
        }


        //ANCA: Ability to add a new friend:
        [HttpPost("{id}/friends/{newFriendId}")]
        public IActionResult AddFriend(int id, int newFriendId)
        {
            var selectedInmate = _inmatesRepo.GetById(id);
            User newFriend = (Inmate)_inmatesRepo.GetById(newFriendId);

            if (newFriend == null)
            {
                return NotFound();
            }
            
            _inmatesRepo.AddFriend(selectedInmate.Id, newFriend);

             return Ok($"{selectedInmate.FirstName} now has a new friend ({newFriend.FirstName} {newFriend.LastName})!");
        }

        //ANCA: Added ability to delete a friend: Note: This does not work if I add a friends manually to a new record!!!! it does not delete them... Logged a bug for it.
        [HttpDelete("{id}/friends/{friendToDeleteId}")]
        public IActionResult DeleteFriend(int id, int friendToDeleteId)
        {
            User selectedInmate = _inmatesRepo.GetById(id);
            User friendToDelete = _inmatesRepo.GetById(friendToDeleteId);
            if (friendToDelete == null)
            {
                return NotFound();
            }
            _inmatesRepo.DeleteFriend(selectedInmate.Id, friendToDelete);

            return Ok($"{friendToDelete.FirstName} {friendToDelete.LastName} is no longer {selectedInmate.FirstName} {selectedInmate.LastName}'s friend. She'd better watch her back!");
        }

        public IActionResult GetAllInmates()
        {
            var allInmates = _inmatesRepo.GetInmates();

            return Ok(allInmates);
        }

        //Beth:
        [HttpGet("{id}/services")]
        public IActionResult GetAllServicesByInmate(int id)
        {
            var selectedUser = _inmatesRepo.GetById(id);
            var services = _inmatesRepo.GetServices(id);
            string combindedString = string.Join("\n \t", services);

            return Ok($"{selectedUser.FirstName} will be offering these services:\n\t{combindedString}");
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var selectedUser = _inmatesRepo.GetById(id);

            return Ok(selectedUser);
        }

        //ANCA: Calculations for number of days since the sentence started and until it ends. I am converting a User type to an Inmate type so that I can access Inmate-specific properties such as sentence dates.
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

        //Monique: Update an inmate
        [HttpPut("{id}/updateInterest")]
        public IActionResult UpdateInmate(int id, Inmate inmate)
        {
            var selectedInmate = _inmatesRepo.GetById(id);
            var updatedInmate = _inmatesRepo.Update(id, inmate);
            return Ok($"{selectedInmate.FirstName}'s interest has now been updated to {selectedInmate.Interest}!");
        }
    }
}
