using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Models;
using SimpleImageGallery.Data.Models;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var hikingImageTags = new List<ImageTag>();
            var cityImageTags = new List<ImageTag>();

            //mock tags to be removed once Db and Image Uploading is fully implemented
            var tag1 = new ImageTag()
            {
                Description = "Adventure",
                Id = 0
            };

            var tag2 = new ImageTag()
            {
                Description = "City",
                Id = 1
            };

            var tag3 = new ImageTag()
            {
                Description = "Location",
                Id = 2
            };

            hikingImageTags.Add(tag1);
            cityImageTags.AddRange(new List<ImageTag>{ tag2, tag3});

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Title = "Hiking Trip",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },
                new GalleryImage()
                {
                    Title = "On The Trail",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },
                new GalleryImage()
                {
                    Title = "City",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = cityImageTags
                }
            };

            var model = new GalleryIndexModel()
            {
                //mock images to be removed after search query is fully implemented
                Images = imageList,
                SearchQuery = ""
            };

            return View(model);
        }
    }
}