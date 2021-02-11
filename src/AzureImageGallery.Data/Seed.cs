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
        public static void SeedData(AzureImageGalleryDbContext appContext)
        {
            if(!appContext.Users.Any())
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
                   appContext.AddRange(user, "Pa$$w0rd");
                }
            }

            if(!appContext.GalleryImages.Any())
            {
                var images = new List<GalleryImage>
                { 
                    new GalleryImage
                    {
                        Title = "Boat 1",
                        Created = DateTime.UtcNow,
                        Url = "/images/boat1.jpeg"
                    },
                    new GalleryImage
                    {
                        Title = "Boat 2",
                        Created = DateTime.UtcNow.AddDays(-30),
                        Url = "/images/boat2.jpeg"
                    },
                    new GalleryImage
                    {
                        Title = "Boat 3",
                        Created = DateTime.UtcNow.AddDays(-9),
                        Url = "https://devimagegallery.blob.core.windows.net/images/fishing-boat-denmark-beach-sea-86699.jpeg"
                    },
                    new GalleryImage
                    {
                        Title = "Food",
                        Created = DateTime.UtcNow,
                        Url = "https://devimagegallery.blob.core.windows.net/images/bread-food-healthy-breakfast.jpg"
                    }
                };

                appContext.AddRange(images);
            }

            appContext.SaveChanges();
        }
    }
}
