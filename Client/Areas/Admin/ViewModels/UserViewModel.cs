﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Cnic { get; set; }
        public string Email { get; set; }
    }
}
