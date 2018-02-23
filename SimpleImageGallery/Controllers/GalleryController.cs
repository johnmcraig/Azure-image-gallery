using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Models;
using SimpleImageGallery.Data.Models;
using SimpleImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService; //implements the interface of IImage - add to scope service in startup
        }

        // Search Query by title and tags
        //public async Task<IActionResult> Index(string imageTitle, string imageTag, string searchString)
        //{
        //    IQueryable<string> titleQuery = from i in _context.Images
        //                                    orderby i.Title
        //                                    select i.Title;

        //    IQueryable<string> tagQuery = from t in _context.Images
        //                                  orderby t.Tags
        //                                  select t.Tags;

        //    var images = from i in _context.Images
        //                 select i;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        images = images.Where(s => s.Title.Contains(searchString));
        //    }

        //    if (!String.IsNullOrEmpty(imageTitle))
        //    {
        //        images = images.Where(x => x.Genre == imageTitle);
        //    }

        //    var imageTitleVM = new ImageTitleViewModel
        //    {
        //        title = new SelectList(await titleQuery.Distinct().ToListAsync()),
        //        images = await images.ToListAsync()
        //    };

        //    return View(await images.ToListAsync());
        //}

        public IActionResult Index()
        {
            var imageList = _imageService.GetAll();

            // Todo: Pages using skip and range
            // How to show a page #

            var model = new GalleryIndexModel()
            {
                Images = imageList
                //SearchQuery = ""
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
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _imageService.DeleteImage(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_imageService.GetById(id));
            }
        }
    }
}