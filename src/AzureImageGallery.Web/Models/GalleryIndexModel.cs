using AzureImageGallery.Data.Models;
using System.Collections.Generic;

namespace AzureImageGallery.Web.Models
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryDetailModel> Images { get; set; }
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
