using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem
{
    public static  class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

        }
        public static void SeedUser(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"

                };
                var result = userManager.CreateAsync(user,"P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"

                };
               var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Patient").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Patient"

                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }


    }
}
