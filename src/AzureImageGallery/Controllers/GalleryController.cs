using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AzureImageGallery.Data.Models;
using AzureImageGallery.Data;
using AzureImageGallery.Models;

namespace AzureImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var imageList = _imageService.GetAll();
            
            var model = new GalleryIndexModel()
            {
                Images = imageList
            };

            return View(model);
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
            GalleryImage imageToEdit = _imageService.GetById(id);
            return View(imageToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GalleryImage changeImage)
        {
            if (!ModelState.IsValid)
            {
                return View(changeImage);
            }

            try
            {
                _imageService.UpdateImage(changeImage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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
            catch (Exception)
            {
                return View(_imageService.GetById(id));
            }
        }
    }
}