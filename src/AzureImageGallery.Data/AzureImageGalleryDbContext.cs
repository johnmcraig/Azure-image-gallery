using Microsoft.EntityFrameworkCore;
using AzureImageGallery.Data.Models;

namespace AzureImageGallery.Data
{
    public class AzureImageGalleryDbContext : DbContext
    {
        public AzureImageGalleryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
    }
}
