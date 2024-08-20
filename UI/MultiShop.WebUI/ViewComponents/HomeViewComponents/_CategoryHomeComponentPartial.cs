using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _CategoryHomeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CategoryHomeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("https://localhost:7135/api/category");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
    }
}
