using Clinkedin2.Model;
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
            newInmate.Id = newId;
            _users.Add(newInmate);
        }
        public void AddWarden(Warden newWarden)
        {
            var newId = 1;
            if (_users.Count > 0)
            {
                newId = _users.Select(u => u.Id).Max() + 1;
            }
            newWarden.Id = newId;
            _users.Add(newWarden);
        }

        public List<User> GetInmates()
        {
            var _inmates = _users.Where(user => user.UserRole == UserRole.Inmate);

            return _inmates.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

    }
}
