using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductImageDTOs;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [Route("ProductImageDetail/{id}"), HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Product Image";
            ViewBag.v0 = "Product Image Operations";

            var responseGet = await _productImageService.GetAllProductImagesAsync(cancellationToken);
            if (responseGet != null)
            {
                return View(responseGet);
            }
            CreateProductImageDTO createProductImageDTO = new()
            {
                ProductID = id,
                Image1 = "",
                Image2 = "",
                Image3 = "",
                Image4 = "",
            };
            var responsePost = await _productImageService.CreateProductImageAsync(createProductImageDTO, cancellationToken);
            return View();
        }

        [Route("ProductImageDetail/{id}"), HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDTO updateProductImageDTO, CancellationToken cancellationToken)
        {
            var response = await _productImageService.UpdateProductImageAsync(updateProductImageDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}