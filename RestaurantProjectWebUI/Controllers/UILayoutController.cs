using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
