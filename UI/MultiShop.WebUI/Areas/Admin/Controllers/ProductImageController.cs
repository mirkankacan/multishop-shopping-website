using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductImageDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductImageDetail/{id}"), HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Product Image";
            ViewBag.v0 = "Product Image Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7135/api/ProductImage/ProductImagesByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode && responseMessage.Content.Headers.ContentLength > 0)
            {
                var response = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDTO>();
                return View(response);
            }
            CreateProductImageDTO createProductImageDTO = new()
            {
                ProductID = id,
                Image1 = "",
                Image2 = "",
                Image3 = "",
                Image4 = "",
            };
            var responsePost = await client.PostAsJsonAsync("https://localhost:7135/api/ProductImage", createProductImageDTO);
            return View();
        }

        [Route("ProductImageDetail/{id}"), HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDTO updateProductImageDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7135/api/ProductImage", updateProductImageDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}