using AzureImageGallery.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureImageGallery.Data
{
    public class SeedData
    {
        public static void SeedImages(AzureImageGalleryDbContext appContext)
        {
            if (!appContext.GalleryImages.Any())
            {
                var images = new List<GalleryImage>
                { 
                    new GalleryImage
                    {
                        Title = "Boat 1",
                        Created = DateTime.UtcNow.AddDays(-31),
                        Url = "https://devimagegallery.blob.core.windows.net/images/boat1.jpeg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Description = "boat",
                           },
                           new ImageTag
                           {
                               Description = "sea",
                           }
                        }
                    },
                    new GalleryImage
                    {
                        Title = "Boat 2",
                        Created = DateTime.UtcNow.AddDays(-30),
                        Url = "https://devimagegallery.blob.core.windows.net/images/boat2.jpeg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Description = "boat",
                           },
                           new ImageTag
                           {
                               Description = "sea",
                           }
                        }
                    },
                    new GalleryImage
                    {
                        Title = "Boat 3",
                        Created = DateTime.UtcNow.AddDays(-7),
                        Url = "https://devimagegallery.blob.core.windows.net/images/fishing-boat-denmark-beach-sea-86699.jpeg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Description = "boat",
                           },
                           new ImageTag
                           {
                               Description = "sea",
                           }
                        }
                    },
                    new GalleryImage
                    {
                        Title = "Food",
                        Created = DateTime.UtcNow,
                        Url = "https://devimagegallery.blob.core.windows.net/images/bread-food-healthy-breakfast.jpg",
                        Tags = new List<ImageTag>
                        {
                           new ImageTag
                           {
                               Description = "food",
                           },
                           new ImageTag
                           {
                               Description = "breakfast",
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
