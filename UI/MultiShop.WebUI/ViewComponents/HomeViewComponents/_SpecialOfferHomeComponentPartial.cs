using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _SpecialOfferHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SpecialOfferHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultSpecialOfferDTO>>("https://localhost:7135/api/SpecialOffer");
            if (response != null)
            {
                return View(response);
            }

            return View();

        }
    }
}
