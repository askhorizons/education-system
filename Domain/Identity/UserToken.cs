using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class UserToken : IdentityUserToken<string>
    {
        public virtual AppUser User { get; set; }
    }
}
