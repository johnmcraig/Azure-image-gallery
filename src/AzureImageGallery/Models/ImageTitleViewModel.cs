using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AzureImageGallery.Controllers
{
    public class ImageTitleViewModel
    {
        public List<ImageController> Images;
        public SelectList Title;
        public string ImageTitle { get; set; }
    }
}