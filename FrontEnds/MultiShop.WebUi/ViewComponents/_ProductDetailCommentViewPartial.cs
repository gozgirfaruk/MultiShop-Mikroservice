using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUi.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ProductDetailCommentViewPartial : ViewComponent
    {
      private readonly ICommentService _commentService;

        public _ProductDetailCommentViewPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.GetCommentForProductId(id);
            return View(values);
           
        }
    }
}
