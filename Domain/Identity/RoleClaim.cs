using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public virtual AppRole Role { get; set; }

    }
}
