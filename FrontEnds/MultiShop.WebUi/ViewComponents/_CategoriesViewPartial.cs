using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.ViewComponents
{
    public class _CategoriesViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
