using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Offer Discount List";
            ViewBag.v0 = "Offer Discount Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultOfferDiscountDTO>>("https://localhost:7135/api/OfferDiscount");
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
        [Route("CreateOfferDiscount"), HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Offer Discount";
            ViewBag.v0 = "Offer Discount Operations";
            return View();
        }
        [Route("CreateOfferDiscount"), HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7135/api/OfferDiscount", createOfferDiscountDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7135/api/OfferDiscount?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}"), HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Offer Discount";
            ViewBag.v0 = "Offer Discount Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<UpdateOfferDiscountDTO>($"https://localhost:7135/api/OfferDiscount/{id}");
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
        [Route("UpdateOfferDiscount/{id}"), HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7135/api/OfferDiscount", updateOfferDiscountDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
    }
}
