using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCompanyDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService companyService)
        {
            _cargoCompanyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var cargoCompanies = await _cargoCompanyService.TGetAllAsync();
            return Ok(cargoCompanies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCompanyById(int id)
        {
            var cargoCompany = await _cargoCompanyService.TGetByIdAsync(id);
            return Ok(cargoCompany);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            if(createCargoCompanyDTO == null)
                return BadRequest("Values could not be retrieved");

            CargoCompany cargoCompanyForCreate = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDTO.CargoCompanyName,
            };
            await _cargoCompanyService.TCreateAsync(cargoCompanyForCreate);
            return Ok("A cargo company has been created successfully");
        }
       
        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.TDeleteAsync(id);
            return Ok("A cargo company has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            if(updateCargoCompanyDTO == null)
                return BadRequest("Values could not be retrieved");

            CargoCompany cargoCompanyForUpdate = new CargoCompany()
            {
                CargoCompanyID=updateCargoCompanyDTO.CargoCompanyID,
                CargoCompanyName=updateCargoCompanyDTO.CargoCompanyName
            };
            await _cargoCompanyService.TUpdateAsync(cargoCompanyForUpdate);
            return Ok("A cargo company has been updated successfully");
        }

    }
}
