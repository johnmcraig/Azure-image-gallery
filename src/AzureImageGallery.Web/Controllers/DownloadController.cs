using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AzureImageGallery.Web.Controllers
{
    [Route("/download")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly string _azureConnectionString;
        private readonly IConfiguration _config;

        public DownloadController(IConfiguration config)
        {
            _config = config;
            _azureConnectionString = _config.GetConnectionString("AzureStorageConnectionString");
        }

        [HttpPost]
        public async Task<IActionResult> Download(string fileName)
        {
            var container = new BlobContainerClient(_azureConnectionString, "images");
            var image = container.GetBlobClient(fileName);

            if(await image.ExistsAsync())
            {
                var a = await image.DownloadAsync();

                return File(a.Value.Content, a.Value.ContentType, fileName);
            }

            return BadRequest();
        }
    }
}