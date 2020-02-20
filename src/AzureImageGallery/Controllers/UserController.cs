using Microsoft.AspNetCore.Mvc;

namespace AzureImageGallery.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
    }
}