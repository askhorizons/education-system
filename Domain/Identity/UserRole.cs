﻿using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
