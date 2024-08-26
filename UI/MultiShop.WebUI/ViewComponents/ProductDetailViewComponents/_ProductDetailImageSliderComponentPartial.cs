﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<UpdateProductDTO>("https://localhost:7135/api/productimage/" + productId);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
    }
}
