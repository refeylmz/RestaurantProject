using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebUI.ViewComponents.BookATableComponents
{
    public class _BookATableNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
