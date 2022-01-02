using CovidTestManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem
{
    public static  class SeedData
    {
        public static void Seed(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUser(userManager);
        }
        private static void SeedUser(UserManager<Person> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var user = new Person
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

            if (userManager.FindByNameAsync("Lead").Result == null)
            {
                var user = new Person
                {
                    UserName = "teamlead@localhost.com",
                    Email = "teamlead@localhost.com"

                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teamleader").Wait();
                }
            }
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
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

            if (!roleManager.RoleExistsAsync("Teamleader").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Teamleader"

                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }


    }
}
