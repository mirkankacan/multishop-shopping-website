using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            var cargoCompanies = await _cargoOperationService.TGetAllAsync();
            return Ok(cargoCompanies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoOperationById(int id)
        {
            var cargoOperation = await _cargoOperationService.TGetByIdAsync(id);
            return Ok(cargoOperation);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDTO createCargoOperationDTO)
        {
            CargoOperation cargoOperationForCreate = new CargoOperation()
            {
                CargoBarcode = createCargoOperationDTO.CargoBarcode,
                Description = createCargoOperationDTO.Description,
                OperationDate = createCargoOperationDTO.OperationDate
            };
            await _cargoOperationService.TCreateAsync(cargoOperationForCreate);
            return Ok("A cargo operation has been created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            await _cargoOperationService.TDeleteAsync(id);
            return Ok("A cargo operation has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            CargoOperation cargoOperationForUpdate = new CargoOperation()
            {
                CargoOperationID = updateCargoOperationDTO.CargoOperationID,
                CargoBarcode = updateCargoOperationDTO.CargoBarcode,
                Description = updateCargoOperationDTO.Description,
                OperationDate = updateCargoOperationDTO.OperationDate,
            };
            await _cargoOperationService.TUpdateAsync(cargoOperationForUpdate);
            return Ok("A cargo operation has been updated successfully");
        }
    }
}
