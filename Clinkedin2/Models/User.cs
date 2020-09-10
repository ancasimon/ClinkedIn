using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PrisonFacility { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UserRole UserRole { get; set; }

        //public User(string firstName, string lastName, Gender gender, string prisonFacility, DateTime dateOfBirth, UserRole userRole)
        //{
        //    //Id = id;
        //    //FirstName = firstName;
        //    //LastName = lastName;
        //    //Gender = gender;
        //    //PrisonFacility = prisonFacility;
        //    //DateOfBirth = dateOfBirth;
        //    //UserRole = userRole;

        //}

    }
}

public enum UserRole
{
    Inmate,
    Warden
}


