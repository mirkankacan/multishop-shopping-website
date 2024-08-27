using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("UpdateProductDetail/{id}"), HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Product Detail";
            ViewBag.v0 = "Product Detail Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7135/api/ProductDetail/GetProductDetailByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode && responseMessage.Content.Headers.ContentLength > 0)
            {
                var response = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDTO>();
                return View(response);
            }
            CreateProductDetailDTO createProductDetailDTO = new()
            {
                ProductID = id,
                ProductDescription = "",
                ProductInfo = ""
            };
            var responsePost = await client.PostAsJsonAsync("https://localhost:7135/api/ProductDetail", createProductDetailDTO);
            return View();
        }

        [Route("UpdateProductDetail/{id}"), HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7135/api/ProductDetail", updateProductDetailDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}