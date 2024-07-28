using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.ViewComponents
{
    public class _RecentProductViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
