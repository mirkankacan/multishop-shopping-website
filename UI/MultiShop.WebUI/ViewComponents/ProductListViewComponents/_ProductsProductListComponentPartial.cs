using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductsProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductsProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultProductWithCategoryDTO>>("https://localhost:7135/api/product/ProductListByCategoryId?id=" + categoryId);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
    }
}