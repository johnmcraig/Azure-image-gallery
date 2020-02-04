using AzureImageGallery.Data.Models;
using System.Collections.Generic;

namespace AzureImageGallery.Models
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
