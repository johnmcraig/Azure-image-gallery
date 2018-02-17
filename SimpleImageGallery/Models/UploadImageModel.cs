using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleImageGallery.Models
{
    public class UploadImageModel
    {
        public string Title { get; set; }
        public string Tags { get; set; } // add logic to parse multiple user tags in the views
        public IFormFile ImageUpload { get; set; } // IFormFile needs Http services.
    }
}
