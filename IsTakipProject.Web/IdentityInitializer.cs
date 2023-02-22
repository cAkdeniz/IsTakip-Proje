using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name="Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("cagatay");
            if (adminUser == null)
            {
                AppUser user = new AppUser()
                {
                    UserName = "cagatay",
                    Email = "cagatayakdeniz16@gmail.com",
                    Name = "Cagatay",
                    Surname = "Akdeniz",
                };
                await userManager.CreateAsync(user, "2242829");
                await userManager.AddToRoleAsync(user,"Admin");
            }
        }
    }
}
