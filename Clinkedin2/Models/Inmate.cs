using Clinkedin2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Models
{
    public class Inmate : User
    {
        public Interest Interests { get; set; }
        public new List<Inmate> Friends { get; set; } = new List<Inmate>();
        public List<Inmate> Enemies { get; set; } = new List<Inmate>();
        public Services Services { get; set; }
        public DateTime SentenceStartDate { get; set; }
        public DateTime SentenceEndDate { get; set; }
        public new UserRole UserRole { get; set; } = UserRole.Inmate;
        
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
