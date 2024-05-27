using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCompanyDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompanyController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var cargoCompanies = await _companyService.TGetAllAsync();
            return Ok(cargoCompanies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCompanyById(int id)
        {
            var cargoCompany = await _companyService.TGetByIdAsync(id);
            return Ok(cargoCompany);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            CargoCompany cargoCompanyForCreate = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDTO.CargoCompanyName,
            };
            await _companyService.TCreateAsync(cargoCompanyForCreate);
            return Ok("A cargo company has been created successfully");
        }
       
        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _companyService.TDeleteAsync(id);
            return Ok("A cargo company has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            CargoCompany cargoCompanyForUpdate = new CargoCompany()
            {
                CargoCompanyID=updateCargoCompanyDTO.CargoCompanyID,
                CargoCompanyName=updateCargoCompanyDTO.CargoCompanyName
            };
            await _companyService.TUpdateAsync(cargoCompanyForUpdate);
            return Ok("A cargo company has been updated successfully");
        }

    }
}
