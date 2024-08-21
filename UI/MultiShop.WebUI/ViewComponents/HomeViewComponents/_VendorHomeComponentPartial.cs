using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.BrandDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _VendorHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _VendorHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultBrandDTO>>("https://localhost:7135/api/Brand");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
    }
}
