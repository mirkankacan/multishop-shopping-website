using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.BrandDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Brand List";
            ViewBag.v0 = "Brand Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultBrandDTO>>("https://localhost:7135/api/Brand");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
        [Route("CreateBrand"), HttpGet]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Brand";
            ViewBag.v0 = "Brand Operations";
            return View();
        }
        [Route("CreateBrand"), HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsJsonAsync("https://localhost:7135/api/Brand", createBrandDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7135/api/Brand?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateBrand/{id}"), HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Brand";
            ViewBag.v0 = "Brand Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<UpdateBrandDTO>($"https://localhost:7135/api/Brand/{id}");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
        [Route("UpdateBrand/{id}"), HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsJsonAsync("https://localhost:7135/api/Brand", updateBrandDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
    }
}
