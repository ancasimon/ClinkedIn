using Clinkedin2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Models
{
    public class Inmate : Person
    {
        public Interest Interests { get; set; }
        public List<Person> Friends { get; set; }
        public List<Person> Enemies { get; set; }
        public Services Services { get; set; }
        public DateTime SentenceStartDate { get; set; }
        public DateTime SentenceEndDate { get; set; }
        public Inmate(int id, string firstName, string lastName, Gender gender, string prisonFacility, DateTime dateOfBirth) :base(id, firstName, lastName, gender, prisonFacility, dateOfBirth, StatusOfPerson.Inmate)
        {
            Friends = new List<Person>();
            Enemies = new List<Person>();
        }
    }
}

public enum Interest
{
    Music,
    Sports,
}

public enum Services
{

}
