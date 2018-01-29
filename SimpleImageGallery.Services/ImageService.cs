using SimpleImageGallery.Data;
using System;
using SimpleImageGallery.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return _dbContext.GalleryImages.Include(i => i.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return _dbContext.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll()
                    .Where(i => i.Tags
                    .Any(t => t.Description == tag));
        }
    }
}
