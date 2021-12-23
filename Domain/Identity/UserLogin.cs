using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class UserLogin : IdentityUserLogin<string>
    {
        public virtual AppUser User { get; set; }
    }
}
