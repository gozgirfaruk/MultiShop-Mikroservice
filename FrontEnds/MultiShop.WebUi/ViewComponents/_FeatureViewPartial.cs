using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.ViewComponents
{
    public class _FeatureViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
