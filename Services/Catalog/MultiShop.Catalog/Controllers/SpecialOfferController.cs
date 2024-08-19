using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var SpecialOfferList = await _specialOfferService.GetAllCategoriesAsync();

            return Ok(SpecialOfferList);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var SpecialOffer = await _specialOfferService.GetByIdSpecialOfferAsync(id);

            return Ok(SpecialOffer);

        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDTO);
            return Ok("A special offer has been created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("A special offer has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDTO);
            return Ok("A special offer has been updated successfully");
        }
    }
}
