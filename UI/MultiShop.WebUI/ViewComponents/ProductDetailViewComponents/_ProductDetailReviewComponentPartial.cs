using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId, CancellationToken cancellationToken)
        {
            var response = await _commentService.GetCommentListByProductId(productId, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
    }
}