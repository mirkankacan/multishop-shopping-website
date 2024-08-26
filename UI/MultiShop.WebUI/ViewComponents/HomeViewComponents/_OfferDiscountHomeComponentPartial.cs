using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _OfferDiscountHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OfferDiscountHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultOfferDiscountDTO>>("https://localhost:7135/api/OfferDiscount");
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
    }
}
