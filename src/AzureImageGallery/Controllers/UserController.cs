using System.Threading.Tasks;
using AzureImageGallery.Data.Models;
using AzureImageGallery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AzureImageGallery.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userMAnager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userMAnager,
            SignInManager<AppUser> signInManager)
        {
            _userMAnager = userMAnager;
            _signInManager = signInManager;
        }
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userMAnager
                    .CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            return View(model);
        }
    }
}