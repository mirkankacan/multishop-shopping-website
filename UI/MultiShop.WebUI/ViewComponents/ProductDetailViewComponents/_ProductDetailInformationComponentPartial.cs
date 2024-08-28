using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7135/api/ProductDetail/GetProductDetailByProductId?id={productId}");
            if (responseMessage.IsSuccessStatusCode && responseMessage.Content.Headers.ContentLength > 0)
            {
                var response = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDTO>();
                return View(response);
            }
            return View();
        }
    }
}