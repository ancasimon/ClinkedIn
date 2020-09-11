using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinkedin2.Models;

namespace Clinkedin2.Model
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
        public List<Inmate> Friends { get; set; } = new List<Inmate>();

    }
}

public enum UserRole
{
    NotSet,
    Inmate,
    Warden
}


