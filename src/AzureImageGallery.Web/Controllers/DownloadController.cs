using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("{name}")]
        public async Task<IActionResult> Download(string name)
        {
            var container = new BlobContainerClient(_azureConnectionString, "images");
            var image = container.GetBlobClient(name);
            
            if(await image.ExistsAsync())
            {
                var a = await image.DownloadAsync();

                return File(a.Value.Content, a.Value.ContentType, name);
            }

            return BadRequest();
        }
    }
}