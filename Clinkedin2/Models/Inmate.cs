using Clinkedin2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Models
{
    public class Inmate : User
    {
        //public Interest Interests { get; set; }
        //public List<User> Friends { get; set; }
        //public List<User> Enemies { get; set; }
        //public Services Services { get; set; }
        //public DateTime SentenceStartDate { get; set; }
        //public DateTime SentenceEndDate { get; set; }
        //public new UserRole UserRole { get; } = UserRole.Inmate;
        //public Inmate(string firstName, string lastName, Gender gender, string prisonFacility, DateTime dateOfBirth) : base( firstName, lastName, gender, prisonFacility, dateOfBirth, UserRole.Inmate)
        //{
        //    Friends = new List<User>();
        //    Enemies = new List<User>();
        //}
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
