using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SimpleImageGallery.Controllers
{
    public class ImageTitleViewModel
    {
        public List<ImageController> images;
        public SelectList title;
        public string imageTitle { get; set; }
    }
}