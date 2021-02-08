using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AzureImageGallery.Data.Models;
using AzureImageGallery.Data;
using AzureImageGallery.Web.Models;
using Microsoft.Extensions.Logging;
using AzureImageGallery.Web.Helpers;
using System.Collections.Generic;

namespace AzureImageGallery.Web.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;
        private readonly ILogger<GalleryController> _logger;

        public GalleryController(IImage imageService, ILogger<GalleryController> logger)
        {
            _imageService = imageService;
            _logger = logger;
        }

        public ActionResult<PaginatedList<GalleryDetailModel>> Index(int pageNumber = 1, int pageSize = 12)
        {
            if (pageNumber < 1)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            };

            var imageList = _imageService.GetAll().Select(images => new GalleryDetailModel
            {
                 Id = images.Id,
                 Title = images.Title,
                 Created = images.Created,
                 Url = images.Url
            }).ToList();

            //var images = new GalleryIndexModel
            //{
            //    Images = imageList,
            //    PageNumber = pageNumber,
            //    PageCount = pageSize
            //};

            return View((imageList, pageNumber, pageSize));
        }

        public IActionResult Detail(int id)
        {
            var image = _imageService.GetById(id);

            var model = new GalleryDetailModel()
            {
                Id = image.Id,
                Title = image.Title,
                Created = image.Created,
                Url = image.Url,
                Tags = image.Tags
                    .Select(t => t.Description)
                    .ToList()
            };

            return View(model);
        }

        // Edit
        // Get
        public IActionResult Edit(int id)
        {
            var imageToEdit = _imageService.GetById(id);

            return View(imageToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GalleryImage changeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _imageService.UpdateImage(changeImage);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return View(changeImage);
            }

        }

        // Delete
        // Get
        public IActionResult Delete(int id)
        {
            return View(_imageService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var image = _imageService.GetById(id);
            
            if(image == null)
            {
                return NotFound();
            }

            try
            {
                _imageService.DeleteImage(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return View(_imageService.GetById(id));
            }
        }
    }
}