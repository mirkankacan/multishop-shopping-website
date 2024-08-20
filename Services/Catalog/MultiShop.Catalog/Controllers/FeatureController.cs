using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var featureList = await _featureService.GetAllFeaturesAsync();

            return Ok(featureList);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var feature = await _featureService.GetByIdFeatureAsync(id);

            return Ok(feature);

        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            await _featureService.CreateFeatureAsync(createFeatureDTO);
            return Ok("A feature has been created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("A feature has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDTO);
            return Ok("A feature has been updated successfully");
        }
    }
}
