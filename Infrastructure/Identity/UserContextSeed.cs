using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    FirstName = "Miruna",
                    LastName = "Chisluca",
                    Email = "miruna.chisluca@gmail.com",
                    EmailConfirmed = true,
                    UserName = "mirsi",
                    PhoneNumber = "0751378457",
                    Address = new Address
                    {
                        FirstName = "Miruna",
                        LastName = "Chisluca",
                        Street = "Aleea Postavaru nr 2, bl. 17",
                        City = "Satu Mare",
                        County = "Satu Mare",
                        ZipCode = "440234"
                    }
                };

                await userManager.CreateAsync(user, "ChiMina*98");
            }
        }

        public static async Task SeedUserRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
