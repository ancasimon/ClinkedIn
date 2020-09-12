using Clinkedin2.Models;
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

        public List<User> GetInmates(UserRole userRole) //ANCA: Any way I can make this a list of Inmates - so that it can return the inmate-specific properties? I get the conversion error that it cannot change User to Inmate error ....
        {
            var _inmates = _users.Where(user => user.UserRole == userRole);

            return _inmates.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }


        public User GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public User Update(int id, User user)
        {
            var userToUpdate = _users.First(user => user.Id == id);
            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.FirstName = user.FirstName;
            //Anca: Need to add all the user properties here!

            return userToUpdate;
        }

        public List<User> GetMyFriends(int id)
        {
            var userLoggedIn = _users.First(User => User.Id == id);
            var userFriends = userLoggedIn.Friends;

            return userFriends;
        }

        public void AddFriend(int id, Inmate newFriend)
        {
            var userLoggedIn = _users.First(User => User.Id == id);
            var userFriends = userLoggedIn.Friends;

            userFriends.Add(newFriend);
        }
    }
}
