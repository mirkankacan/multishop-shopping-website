using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCustomerDTOs;
using MultiShop.Cargo.DTOLayer.DTOs.CargoDetailDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var cargoCustomers = await _cargoDetailService.TGetAllAsync();
            return Ok(cargoCustomers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoDetailById(int id)
        {
            var cargoCustomer = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(cargoCustomer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDTO createCargoDetailDTO)
        {
            CargoDetail cargoDetailForCreate = new CargoDetail()
            {
                SenderCustomer = createCargoDetailDTO.SenderCustomer,
                ReceiverCustomer = createCargoDetailDTO.ReceiverCustomer,
                Barcode = createCargoDetailDTO.Barcode,
                CargoCompanyID = createCargoDetailDTO.CargoCompanyID
            };
            await _cargoDetailService.TCreateAsync(cargoDetailForCreate);
            return Ok("A cargo detail has been created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _cargoDetailService.TDeleteAsync(id);
            return Ok("A cargo detail has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            CargoDetail cargoDetailForUpdate = new CargoDetail()
            {
                CargoDetailID = updateCargoDetailDTO.CargoDetailID,
                SenderCustomer = updateCargoDetailDTO.SenderCustomer,
                ReceiverCustomer = updateCargoDetailDTO.ReceiverCustomer,
                Barcode = updateCargoDetailDTO.Barcode,
                CargoCompanyID = updateCargoDetailDTO.CargoCompanyID
          
            };
            await _cargoDetailService.TUpdateAsync(cargoDetailForUpdate);
            return Ok("A cargo detail has been updated successfully");
        }
    }
}
