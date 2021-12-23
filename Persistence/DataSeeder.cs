using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeder
    {
        public static async Task SeedAsync(
            DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "salman@askhorizons.com",
                    FirstName = "Salman",
                    LastName = "Malik",
                    PhoneNumber = "+923308451234",
                    UserName = "6110117675441",
                    Created = DateTime.Now
                };

                await userManager.CreateAsync(user, "password");
            }
        }
    }
}
