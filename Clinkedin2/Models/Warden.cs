﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinkedin2.Models
{
    public class Warden : User
    {
        public Warden()
        {
            UserRole = UserRole.Warden;

        }
    }
}
