using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Models
{
    public class Inmate : User
    {

        public DateTime SentenceStartDate { get; set; }
        public DateTime SentenceEndDate { get; set; }


        public Inmate()
        {
            UserRole = UserRole.Inmate;
        }
    }

}

