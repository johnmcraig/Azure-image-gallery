using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Models;
using Microsoft.Extensions.Configuration;
using SimpleImageGallery.Services;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace SimpleImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private IConfiguration _config;
        private ImageService _imageService;
        private string AzureConnectionString { get; }
        

        public ImageController(IConfiguration config, ImageService imageService)
        {
            _config = config;
            _imageService = imageService;
            AzureConnectionString = _config["AzureStorageConnectionString"];   
        }

        public IActionResult Upload()
        {
            var model = new UploadImageModel();
           // present a user with an empty form rather than pre-populated fields that get posted back to another action result
            return View(model);
        }

        // Post Method
        [HttpPost]
        public IActionResult UploadNewImage(IFormFile file)
        {
            var container = _imageService.GetBlobContainer(AzureConnectionString, "images");
            // In order to upload an image, parse the Content Disposition Response Header (CDRH) as a file that uses IFormFile from the systems AspNetCore.Http
            // store the CDRH in a variable and use the systems Http Headers
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

            return Ok();
        }
    }
}