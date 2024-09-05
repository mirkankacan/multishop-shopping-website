using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ContactDTOs;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO createContactDTO, CancellationToken cancellationToken)
        {
            createContactDTO.IsRead = false;
            createContactDTO.SendDate = DateTime.Now;
            var response = await _contactService.CreateContactAsync(createContactDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}