using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCustomerDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService customerService)
        {
            _cargoCustomerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCustomerList()
        {
            var cargoCustomers = await _cargoCustomerService.TGetAllAsync();
            return Ok(cargoCustomers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCustomerById(int id)
        {
            var cargoCustomer = await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(cargoCustomer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            CargoCustomer cargoCustomerForCreate = new CargoCustomer()
            {
                Name = createCargoCustomerDTO.Name,
                Surname = createCargoCustomerDTO.Surname,
                Phone = createCargoCustomerDTO.Phone,
                Email = createCargoCustomerDTO.Email,
                Address = createCargoCustomerDTO.Address,
                City = createCargoCustomerDTO.City,
                District = createCargoCustomerDTO.District,
                IsPremium = createCargoCustomerDTO.IsPremium
            };
            await _cargoCustomerService.TCreateAsync(cargoCustomerForCreate);
            return Ok("A cargo customer has been created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);
            return Ok("A cargo customer has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            CargoCustomer cargoCustomerForUpdate = new CargoCustomer()
            {
                CargoCustomerID = updateCargoCustomerDTO.CargoCustomerID,
                Name = updateCargoCustomerDTO.Name,
                Surname = updateCargoCustomerDTO.Surname,
                Phone = updateCargoCustomerDTO.Phone,
                Email = updateCargoCustomerDTO.Email,
                Address = updateCargoCustomerDTO.Address,
                City = updateCargoCustomerDTO.City,
                District = updateCargoCustomerDTO.District,
                IsPremium = updateCargoCustomerDTO.IsPremium
            };
            await _cargoCustomerService.TUpdateAsync(cargoCustomerForUpdate);
            return Ok("A cargo customer has been updated successfully");
        }
    }
}
