using Clinkedin2.Model;
using Clinkedin2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.DataAccess
{
    public class UserRepository
    {
        static List<User> _users = new List<User>();
        static List<User> _inmates = new List<User>();

        public void Add(User userToAdd)
        {
            var newId = 1;
            if(_users.Count > 0)
            {
                newId = _users.Select(u => u.Id).Max() + 1;
            }
            userToAdd.Id = newId;
            _users.Add(userToAdd);
        }

        public List<User> GetInmates()
        {
           _inmates = (List<User>)_users.Where(user => user.UserRole == UserRole.Inmate);

            return _inmates;
        }

    }
}
