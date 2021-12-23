using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual AppUser User { get; set; }
    }
}
