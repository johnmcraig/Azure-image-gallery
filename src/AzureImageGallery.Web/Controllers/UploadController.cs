using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureImageGallery.Data;
using AzureImageGallery.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzureImageGallery.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly string _azureConnectionString;
        private readonly IConfiguration _config;
        private readonly IImage _imageService;

        public UploadController(IConfiguration config, IImage imageService)
        {
            _config = config;
            _imageService = imageService;
            _azureConnectionString = _config.GetConnectionString("AzureStorageConnectionString");
        }

        public IActionResult Index()
        {
            var vm = new UploadImageModel();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(string title, string tags)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var image = formCollection.Files.First();

                if(image.Length > 0)
                {
                    var container = new BlobContainerClient(_azureConnectionString, "images");
                    var createResponse = await container.CreateIfNotExistsAsync();

                    if(createResponse != null && createResponse.GetRawResponse().Status == 201)
                    {
                        await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                    }

                    var blob = container.GetBlobClient(image.FileName.Trim('"'));
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                    using(var fileStream = image.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = image.ContentType });
                    }

                    await _imageService.SetImage(title, tags, blob.Uri);

                    return RedirectToAction(nameof(GalleryController.Index), "Gallery", blob.Uri.ToString());
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
