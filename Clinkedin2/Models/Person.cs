using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PrisonFacility { get; set; }
        public DateTime DateOfBirth { get; set; }

        public StatusOfPerson StatusOfPerson { get; set; }

        public Person(int id, string firstName, string lastName, Gender gender, string prisonFacility, DateTime dateOfBirth, StatusOfPerson statusOfPerson)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PrisonFacility = prisonFacility;
            DateOfBirth = dateOfBirth;
            StatusOfPerson = statusOfPerson;

        }

    }
}

public enum StatusOfPerson
{
    Inmate,
    Warden
}


