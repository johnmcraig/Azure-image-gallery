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

        public IActionResult Index(string sortOrder, string currentfilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var imageList = _imageService.GetAll();  // Todo: Pages using skip and range // How to show a page #
            
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

        //Post
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

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, GalleryImage imageToDelete, IFormCollection collection)
        {
            try
            {
                _imageService.DeleteImage(imageToDelete);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(_imageService.GetById(id));
            }
        }
    }
}