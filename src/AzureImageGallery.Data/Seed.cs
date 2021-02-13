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
                        Id = Guid.NewGuid(),
                        DisplayName = "Admin1",
                        UserName = "admin1",
                        Email = "admin1@test.com"
                    },
                    new AppUser
                    {
                        Id = Guid.NewGuid(),
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                    new AppUser
                    {
                        Id = Guid.NewGuid(),
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
                        Id = 1,
                        Title = "Boat 1",
                        Created = DateTime.UtcNow,
                        Url = "https://devimagegallery.blob.core.windows.net/images/boat1.jpeg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Id = 1,
                               Description = "boat",
                               //ImageId = 1
                           },
                           new ImageTag
                           {
                               Id = 2,
                               Description = "sea",
                               //ImageId = 1
                           }
                        }
                    },
                    new GalleryImage
                    {
                        Id = 2,
                        Title = "Boat 2",
                        Created = DateTime.UtcNow.AddDays(-30),
                        Url = "https://devimagegallery.blob.core.windows.net/images/boat2.jpeg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Id = 1,
                               Description = "boat",
                               //ImageId = 2
                           },
                           new ImageTag
                           {
                               Id = 2,
                               Description = "sea",
                               //ImageId = 2
                           }
                        }
                    },
                    new GalleryImage
                    {
                        Id = 3,
                        Title = "Boat 3",
                        Created = DateTime.UtcNow.AddDays(-7),
                        Url = "https://devimagegallery.blob.core.windows.net/images/fishing-boat-denmark-beach-sea-86699.jpeg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Id = 1,
                               Description = "boat",
                               //ImageId = 3
                           },
                           new ImageTag
                           {
                               Id = 2,
                               Description = "sea",
                               //ImageId = 3
                           }
                        }
                    },
                    new GalleryImage
                    {
                        Id = 4,
                        Title = "Food",
                        Created = DateTime.UtcNow,
                        Url = "https://devimagegallery.blob.core.windows.net/images/bread-food-healthy-breakfast.jpg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Id = 3,
                               Description = "food",
                               //ImageId = 4
                           },
                           new ImageTag
                           {
                               Id = 4,
                               Description = "breakfast",
                               //ImageId = 4
                           }
                        }
                    }
                };

                appContext.AddRange(images);
            }

            appContext.SaveChanges();
        }
    }
}
