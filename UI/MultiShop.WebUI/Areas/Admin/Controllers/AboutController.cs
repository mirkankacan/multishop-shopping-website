using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.AboutDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "About List";
            ViewBag.v0 = "About Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultAboutDTO>>("https://localhost:7135/api/About");
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
        [Route("CreateAbout"), HttpGet]
        public IActionResult CreateAbout()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New About";
            ViewBag.v0 = "About Operations";
            return View();
        }
        [Route("CreateAbout"), HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7135/api/About", createAboutDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7135/api/About?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateAbout/{id}"), HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update About";
            ViewBag.v0 = "About Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<UpdateAboutDTO>($"https://localhost:7135/api/About/{id}");
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
        [Route("UpdateAbout/{id}"), HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7135/api/About", updateAboutDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
