using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinkedin2.Models;

namespace Clinkedin2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string PrisonFacility { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserRole UserRole { get; set; }
        public List<User> Friends { get; set; } = new List<User>();
        public List<User> Enemies { get; set; } = new List<User>();
        public string Interest { get; set; }
        public List<string> Service { get; set; } = new List<string>();

        /*internal void GetAllServicesByInmate(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}

public enum UserRole
{
    NotSet,
    Inmate,
    Warden
}


