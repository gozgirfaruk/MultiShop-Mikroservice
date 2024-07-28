using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.ViewComponents
{
    public class _BrandFooterViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
