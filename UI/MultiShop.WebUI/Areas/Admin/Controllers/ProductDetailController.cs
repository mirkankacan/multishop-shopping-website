using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [Route("UpdateProductDetail/{id}"), HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Product Detail";
            ViewBag.v0 = "Product Detail Operations";

            var responseGet = await _productDetailService.GetProductDetailByProductId(id, cancellationToken);
            if (responseGet != null)
            {
                return View(responseGet);
            }
            CreateProductDetailDTO createProductDetailDTO = new()
            {
                ProductID = id,
                ProductDescription = "",
                ProductInfo = ""
            };
            var responsePost = await _productDetailService.CreateProductDetailAsync(createProductDetailDTO, cancellationToken);
            if (responsePost.IsSuccessStatusCode)
            {
                return View();
            }
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [Route("UpdateProductDetail/{id}"), HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO, CancellationToken cancellationToken)
        {
            var response = await _productDetailService.UpdateProductDetailAsync(updateProductDetailDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}