using AzureImageGallery.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureImageGallery.Data
{
    public class Seed
    {
        public static async Task SeedData(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Admin1",
                        UserName = "admin1",
                        Email = "admin1@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    }
                };

                foreach (var user in users)
                {
                   await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}
