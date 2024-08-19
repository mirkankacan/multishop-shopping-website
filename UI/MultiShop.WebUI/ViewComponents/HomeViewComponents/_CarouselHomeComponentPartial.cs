using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _CarouselHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarouselHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseValue = await client.GetFromJsonAsync<List<ResultFeatureSliderDTO>>("https://localhost:7135/api/FeatureSlider");
            if (responseValue != null)
            {
                return View(responseValue);
            }
            return View();
        }
    }
}
