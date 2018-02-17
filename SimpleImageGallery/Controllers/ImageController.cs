using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Models;

namespace SimpleImageGallery.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Upload()
        {
            var model = new UploadImageModel();
           // present a user with an empty form rather than pre-populated fields that get posted back to another action result
            return View(model);
        }

        // Post Method
        [HttpPost]
        public IActionResult UploadNewImage()
        {
            return Ok();
        }
    }
}