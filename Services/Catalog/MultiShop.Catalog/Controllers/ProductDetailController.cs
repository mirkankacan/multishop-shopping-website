using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var productDetailList = await _productDetailService.GetAllProductDetailsAsync();

            return Ok(productDetailList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);

            return Ok(productDetail);
        }

        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var productDetail = await _productDetailService.GetProductDetailByProductId(id);

            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDetailDTO createProductDetailDTO)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDTO);
            return Ok("A product detail has been created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("A product detail has been deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDTO);
            return Ok("A product detail has been updated successfully");
        }
    }
}