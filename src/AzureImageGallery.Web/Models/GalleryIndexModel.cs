using AzureImageGallery.Data.Models;
using System.Collections.Generic;

namespace AzureImageGallery.Models
{
    public class GalleryIndexModel
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public bool HasNext { get; set; }
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
