using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Data.Models;
using SimpleImageGallery.Models;
using System;
using System.Collections.Generic;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var hikingImageTags = new List<ImageTag>();
            var cityImageTags = new List<ImageTag>();

            var tag1 = new ImageTag()
            {
                Description = "Adventure",
                Id = 0
            };

            var tag2 = new ImageTag()
            {
                Description = "Urban",
                Id = 1
            };

            var tag3 = new ImageTag()
            {
                Description = "City",
                Id = 2
            };

            hikingImageTags.Add(tag1);
            cityImageTags.AddRange(new List<ImageTag> { tag2, tag3 });

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
                    Title = "On the Trail",
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
                Images = imageList
            };

            return View();
        }
    }
}