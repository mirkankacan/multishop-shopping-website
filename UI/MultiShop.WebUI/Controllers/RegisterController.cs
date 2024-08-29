using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.IdentityDTOs.RegisterDTOs;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDTO createRegisterDTO)
        {
            if (createRegisterDTO.Password != createRegisterDTO.ConfirmPassword)
            {
                return View();
            }
            if (createRegisterDTO.TermsAndPolicy == false)
            {
                return View();
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:5001/api/register", createRegisterDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}