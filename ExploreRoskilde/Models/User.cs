﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreRoskilde.Models
{
    public class User
    { 
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Emial { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
