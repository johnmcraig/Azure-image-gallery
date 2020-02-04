using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AzureImageGallery.Data;
using AzureImageGallery.Models;

namespace AzureImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private IConfiguration _config;

        private IImage _imageService;

        private string AzureConnectionString { get; }

        public ImageController(IConfiguration config, IImage imageService)
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
        public async Task<IActionResult> UploadNewImage(IFormFile file, string title, string tags)
        {
            var container = _imageService.GetBlobContainer(AzureConnectionString, "images");
            
            // In order to upload an image, parse the Content Disposition Response Header (CDRH) as a file that uses IFormFile from the systems AspNetCore.Http
            // store the CDRH in a variable and use the systems Http Headers
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            
            // Grab the file to upload and trim the quotes
            var fileName = content.FileName.Trim('"');
            
            // Get a reference from a Block Blob, then pass in the fileName
            var blockBlob = container.GetBlockBlobReference(fileName);
            
            // upload the block blob and file then make it asyncroness. This is a method that passes the file to the OpenReadStream
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

            // use the imageService to set the Image that is uploaded and pass the title, tags, and location from the Block Blob (method refrenced in ImageService data library)
            await _imageService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Gallery");
        }
    }
}