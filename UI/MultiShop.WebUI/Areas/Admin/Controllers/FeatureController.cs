using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Feature List";
            ViewBag.v0 = "Feature Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultFeatureDTO>>("https://localhost:7135/api/Feature");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
        [Route("CreateFeature"), HttpGet]
        public IActionResult CreateFeature()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Feature";
            ViewBag.v0 = "Feature Operations";
            return View();
        }
        [Route("CreateFeature"), HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsJsonAsync("https://localhost:7135/api/Feature", createFeatureDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7135/api/Feature?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeature/{id}"), HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Feature";
            ViewBag.v0 = "Feature Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<UpdateFeatureDTO>($"https://localhost:7135/api/Feature/{id}");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
        [Route("UpdateFeature/{id}"), HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsJsonAsync("https://localhost:7135/api/Feature", updateFeatureDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
