using AzureImageGallery.Data;
using System;
using AzureImageGallery.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AzureImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly AzureImageGalleryDbContext _dbContext;

        public ImageService(AzureImageGalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return _dbContext.GalleryImages
                    .AsNoTracking()
                    .Include(i => i.Tags)
                    .OrderByDescending(i => i.Created)
                    .ToList();
        }

        public IEnumerable<GalleryImage> GetAllWithPaging(int pageNumber, int pageSize)
        {
            int skip = pageSize * (pageNumber - 1);
            int pageCount = _dbContext.GalleryImages.Count();
            int capacity = skip + pageSize;
            bool hasNext = pageCount > capacity;

            return _dbContext.GalleryImages
                    .Include(i => i.Tags)
                    .OrderByDescending(i => i.Created)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();
        }

        // Only call down a range of images
        public IEnumerable<GalleryImage> Range(int skip, int take)
        {
            return _dbContext.GalleryImages
                    .Include(i => i.Tags)
                    .OrderByDescending(i => i.Created)
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }

        public GalleryImage GetById(int id)
        {
            return GetAll()
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll()
                    .Where(i => i.Tags
                    .Any(t => t.Description == tag));
        }

        public void UpdateImage(GalleryImage changeImage)
        {
            _dbContext.Entry(changeImage).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteImage(int id)
        {
            var image = _dbContext.GalleryImages
                .Include(i => i.Tags)
                .FirstOrDefault(i => i.Id == id);

            _dbContext.GalleryImages.Remove(image);
            _dbContext.SaveChanges();
        }

        public async Task SetImage(string title, string tags, Uri uri)
        {
            // create reference to SQL database
            var image = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags), // handle tags that are null. Pass them as a form as a comma separated from the list
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
            };

            _dbContext.Add(image);
            await _dbContext.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {
              return tags.Split(", ")
                .Select(tag => new ImageTag
                {
                    Description = tag
                }).ToList();
        }
    }
}
