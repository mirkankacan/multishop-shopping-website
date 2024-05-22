using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

        public AddressController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, UpdateAddressCommandHandler updateAddressCommandHandler, CreateAddressCommandHandler createAddressCommandHandler, DeleteAddressCommandHandler deleteAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var addresses = await _getAddressQueryHandler.Handle();
            return Ok(addresses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id) 
        {
            var address = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(address);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand cCommand)
        {
            await _createAddressCommandHandler.Handle(cCommand);
            return Ok("An address has been created");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand uCommand)
        {
            await _updateAddressCommandHandler.Handle(uCommand);
            return Ok("An address has been updated");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));
            return Ok("An address has been deleted");
        }
    }
}
