using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.ViewComponents
{
    public class _FeatureProductsViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
