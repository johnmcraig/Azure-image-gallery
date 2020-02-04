using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AzureImageGallery.Data.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; } // Publush date

        public string Url { get; set; } // images are hosted on Azure Blob storage "cloud", so we need to access the images through a Url that points to the blobs.
        
        public virtual IEnumerable<ImageTag> Tags { get; set; }
    }
}
