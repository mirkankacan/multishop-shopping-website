using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _FeaturedProductsHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FeaturedProductsHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultProductDTO>>("https://localhost:7135/api/product");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
    }
}
