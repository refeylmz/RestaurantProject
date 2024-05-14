using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebUI.Controllers
{
    public class AboutUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
