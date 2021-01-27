using AzureImageGallery.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AzureImageGallery.Models
{
    public class ImageTitleViewModel
    {
        public List<GalleryImage> Images;
        public SelectList Title;
        public string ImageTitle { get; set; }
    }
}