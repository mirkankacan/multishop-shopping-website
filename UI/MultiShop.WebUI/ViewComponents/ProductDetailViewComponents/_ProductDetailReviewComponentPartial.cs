using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CommentDTOs;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultCommentDTO>>($"https://localhost:7171/api/Comment/CommentListByProductId?productId={productId}");
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
    }
}