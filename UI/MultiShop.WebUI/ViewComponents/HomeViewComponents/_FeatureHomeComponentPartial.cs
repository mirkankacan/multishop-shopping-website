using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _FeatureHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FeatureHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultFeatureDTO>>("https://localhost:7135/api/Feature");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
    }
}
