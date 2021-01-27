using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AzureImageGallery.Data;
using AzureImageGallery.Models;

namespace AzureImageGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImage _imageService;

        public HomeController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var imageList = _imageService.Range(0,12);

            var model = new GalleryIndexModel()
            {
                Images = imageList
            };

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
