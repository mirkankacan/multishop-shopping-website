using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var BrandList = await _brandService.GetAllBrandsAsync();

            return Ok(BrandList);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var Brand = await _brandService.GetByIdBrandAsync(id);

            return Ok(Brand);

        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            await _brandService.CreateBrandAsync(createBrandDTO);
            return Ok("A Brand has been created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("A Brand has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            await _brandService.UpdateBrandAsync(updateBrandDTO);
            return Ok("A Brand has been updated successfully");
        }
    }
}
