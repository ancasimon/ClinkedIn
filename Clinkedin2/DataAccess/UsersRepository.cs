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
        //static List<User> _inmates = new List<User>();
        static List<User> _users = new List<User>();
        //static UsersRepository()
        //{
        //    _inmates = (List<User>)_users.Where(user => user.UserRole == UserRole.Inmate);

        //}

        public void AddInmate(User newInmate)
        {
            var newId = 1;
            if(_users.Count > 0)
            {
                newId = _users.Select(u => u.Id).Max() + 1;
            }
            newInmate.Id = newId;
            newInmate.UserRole = UserRole.Inmate;
            //_inmates.Add(newInmate);
            _users.Add(newInmate);
        }

        public List<User> GetInmates()
        {
            var _inmates = _users.Where(user => user.UserRole == UserRole.Inmate);

            return (List<User>)_inmates.ToList();
        }

    }
}
