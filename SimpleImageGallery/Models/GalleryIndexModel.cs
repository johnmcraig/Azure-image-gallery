using SimpleImageGallery.Data.Models;
using System.Collections.Generic;

namespace SimpleImageGallery.Models
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
