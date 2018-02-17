using SimpleImageGallery.Data;
using System;
using SimpleImageGallery.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace SimpleImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly SimpleImageGalleryDbContext _dbContext;

        public ImageService(SimpleImageGalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _dbContext.GalleryImages
                    .Include(i => i.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll()
                .Where(i => i.Id == id)
                .First();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll()
                    .Where(i => i.Tags
                    .Any(t => t.Description == tag));
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString); //check to get storage file
            var blobClient = storageAccount.CreateCloudBlobClient(); //get direct reference
            return blobClient.GetContainerReference(containerName); //get valid storage container
        }

        public async Task SetImage(string title, string tags, Uri uri)
        {
            // create reference to SQL database
            var image = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags), // handle tags that are null/empty :: Pass them as a form as a comma seperated from the list
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
            };

            _dbContext.Add(image);
            await _dbContext.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {

              return tags.Split(",") //allows for comma seperation on multiple string values
                .Select(tag => new ImageTag
                {
                    Description = tag
                }).ToList();

            // Refactored code above :: below is old way to iterate through image tags 
            //var tagList = tag.Split(",").ToList();
            //var imageTags = new List<ImageTag>();

            //foreach(var tag in tagList)
            //{
            //    imageTags.Add(new ImageTag
            //    {
            //        Description = tag
            //    });
            //}

            //return imageTags;
        }
    }
}
