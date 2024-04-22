using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
