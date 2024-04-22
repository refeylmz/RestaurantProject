using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
