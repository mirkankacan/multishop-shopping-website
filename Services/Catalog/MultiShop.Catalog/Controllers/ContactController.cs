using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService ContactService)
        {
            _contactService = ContactService;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var ContactList = await _contactService.GetAllContactsAsync();

            return Ok(ContactList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var Contact = await _contactService.GetByIdContactAsync(id);

            return Ok(Contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            await _contactService.CreateContactAsync(createContactDTO);
            return Ok("A contact has been created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return Ok("A contact has been deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            await _contactService.UpdateContactAsync(updateContactDTO);
            return Ok("A contact has been updated successfully");
        }
    }
}