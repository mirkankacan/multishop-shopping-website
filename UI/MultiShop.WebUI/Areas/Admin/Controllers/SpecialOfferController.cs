using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Special Offer List";
            ViewBag.v0 = "Special Offer Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultSpecialOfferDTO>>("https://localhost:7135/api/SpecialOffer");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
        [Route("CreateSpecialOffer"), HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Special Offer";
            ViewBag.v0 = "Special Offer Operations";
            return View();
        }
        [Route("CreateSpecialOffer"), HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsJsonAsync("https://localhost:7135/api/SpecialOffer", createSpecialOfferDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7135/api/SpecialOffer?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}"), HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Special Offer";
            ViewBag.v0 = "Special Offer Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<UpdateSpecialOfferDTO>($"https://localhost:7135/api/SpecialOffer/{id}");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
        [Route("UpdateSpecialOffer/{id}"), HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsJsonAsync("https://localhost:7135/api/SpecialOffer", updateSpecialOfferDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
