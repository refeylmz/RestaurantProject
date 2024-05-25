using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
