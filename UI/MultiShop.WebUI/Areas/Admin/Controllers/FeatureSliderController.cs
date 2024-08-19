using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Feature Slider List";
            ViewBag.v0 = "Feature Slider Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultFeatureSliderDTO>>("https://localhost:7135/api/FeatureSlider");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
        [Route("CreateFeatureSlider"), HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Feature Slider";
            ViewBag.v0 = "Feature Slider Operations";
            return View();
        }
        [Route("CreateFeatureSlider"), HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            createFeatureSliderDTO.Status = false;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsJsonAsync("https://localhost:7135/api/FeatureSlider", createFeatureSliderDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7135/api/FeatureSlider?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{id}"), HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Feature Slider";
            ViewBag.v0 = "Feature Slider Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<UpdateFeatureSliderDTO>($"https://localhost:7135/api/FeatureSlider/{id}");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
        [Route("UpdateFeatureSlider/{id}"), HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsJsonAsync("https://localhost:7135/api/FeatureSlider", updateFeatureSliderDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
