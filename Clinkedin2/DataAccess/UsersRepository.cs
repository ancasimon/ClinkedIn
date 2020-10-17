using Clinkedin2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.DataAccess
{
    public class UsersRepository
    {
        static List<User> _users = new List<User>();

        public void AddInmate(Inmate newInmate)
        {
            var newId = 1;
            if (_users.Count > 0)
            {
                newId = _users.Select(u => u.Id).Max() + 1;
            }
            if (newInmate.Id == 0) //ANCA: I ran into an issue where the program would reassign new IDs to the default inmate records I had already created so I added this condition to keep the original IDs assigned. 
            {
                newInmate.Id = newId;
            }
            _users.Add(newInmate);
        }
        public void AddWarden(Warden newWarden)
        {
            var newId = 1;
            if (_users.Count > 0)
            {
                newId = _users.Select(u => u.Id).Max() + 1;
            }
            if (newWarden.Id == 0)
            {
                newWarden.Id = newId;
            }
            _users.Add(newWarden);
        }
        //ANCA Note: I changed this to a type of Inmate so that I can get the sentence info from the records.
        public List<Inmate> GetInmates() 
        {
            var _inmates = _users.Where(user => user.UserRole == UserRole.Inmate);
            List<Inmate> inmateClassRecords = new List<Inmate>();
            foreach (var inmate in _inmates)
            {
                var inmateClassRecord = (Inmate)Convert.ChangeType(inmate, typeof(Inmate));
                inmateClassRecords.Add(inmateClassRecord);
            }

            return inmateClassRecords.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

           public User GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }


        public List<string> GetServices(int id)
        {
            var inmateService = _users.First(user => user.Id == id);
            var services = inmateService.Service;

            return services.ToList();
        }

        //ANCA: Using the method below to display one's friends:
        public List<String> GetMyFriends(int id)
        {
            var allInmates = GetInmates();
            var userLoggedIn = allInmates.First(i => i.Id == id);
            var userFriends = userLoggedIn.Friends;
            string friendName;
            List<string> friendNames = new List<string>(); //to display just their names, I am copying them to strings and putting them in a list.
            foreach (var person in userFriends)
            {
                friendName = person.FirstName.ToString();
                friendNames.Add(friendName);
            }

            return friendNames;
        }

        //Anca: get friends of friends:
        public List<string> GetFriendsOfFriends(int id)
        {
            var allInmates = GetInmates();
            var myRecord = allInmates.First(i => i.Id == id);
            var myFriends = myRecord.Friends;
            List<User> friendsOfMyFriend = new List<User>();
            Dictionary<string, List<string>> friendsWithMyFriends = new Dictionary<string, List<string>>();

            string friendName;
            string connectedFriendName;
            List<string> friendNames = new List<string>();
            List<string> oneBigListOfFriendsOfMyFriends = new List<string>();
            List<string> distictNamesInOneBigList = new List<string>();

            foreach (var person in myFriends)
            {
                //Find my friends, create a string of each one's first names and capture their friends in a new list of users:
                friendName = person.FirstName.ToString();
                friendsOfMyFriend = person.Friends;
                
                //get friends of friends in one single big list!
                foreach(var individual in friendsOfMyFriend)
                {
                    connectedFriendName = individual.FirstName.ToString();
                    oneBigListOfFriendsOfMyFriends.Add(connectedFriendName);
                    distictNamesInOneBigList = oneBigListOfFriendsOfMyFriends.Distinct().ToList();
                }
            }

            return distictNamesInOneBigList;
        }

        //Anca: Ability to add a new friend:
        public void AddFriend(int id, User newFriend)
        {
            var userLoggedIn = _users.First(User => User.Id == id);
            var userFriends = userLoggedIn.Friends;

            userFriends.Add(newFriend);
        }

        //ANCA: Ability to delete a friend:
        public void DeleteFriend(int id, User friendToDelete)
        {
            var userLoggedIn = _users.First(User => User.Id == id);
            userLoggedIn.Friends.Remove(friendToDelete);
        }


        //ANCA: Calculations for number of days since the sentence started and until it ends below. I am converting a User type to an Inmate type so that I can access Inmate-specific properties such as sentence dates.
        public int CalculateRemainingSentenceDays(int id)
        {
            var currentInmates = GetInmates();
            var userLoggedIn = currentInmates.First(User => User.Id == id);
            var inmateEndDate = userLoggedIn.SentenceEndDate.ToOADate();
            var currentDate = DateTime.Now.ToOADate();
            var daysRemaining = inmateEndDate - currentDate;

            return (int)daysRemaining;
        }

        public int CalculateCompletedSentenceDays(int id)
        {
            var currentInmates = GetInmates();
            var userLoggedIn = currentInmates.First(User => User.Id == id);
            var inmateStartDate = userLoggedIn.SentenceStartDate.ToOADate();
            var currentDate = DateTime.Now.ToOADate();
            var daysCompleted = currentDate - inmateStartDate;

            return (int)daysCompleted;
        }

        //Monique:
        public List<User> GetInterest(int id)//must pass this in
        {
            var userInterest = _users.FirstOrDefault(user => user.Id == id)?.Interest;//prevents null error
            var _matchingInterest = _users.Where(user => userInterest == user.Interest && user.Id != id); // add this && to prevent from getting yourself

            return _matchingInterest.ToList();
        }
        //Monique added Enemy getter
        public List<User> GetMyEnemies(int id)
        {
            var userLoggedIn = _users.First(User => User.Id == id);
            var userEnemies = userLoggedIn.Enemies;
            return userEnemies;
        }

        public void AddEnemies(int id, Inmate newEnemies)
        {
            var userLoggedIn = _users.First(User => User.Id == id);
            var userEnemies = userLoggedIn.Enemies;
            userEnemies.Add(newEnemies);

        }
        //Monique: this method updates an Inmate interest
        public Inmate Update(int id, Inmate inmate)
        {
            var inmateToUpdate = GetById(id);

           inmateToUpdate.Interest = inmate.Interest;
           
            return (Inmate)inmateToUpdate;
        }

    }
}
