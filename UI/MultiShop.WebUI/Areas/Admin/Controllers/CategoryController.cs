using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Category List";
            ViewBag.v0 = "Category Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("https://localhost:7135/api/category");
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
        [Route("CreateCategory"), HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Category";
            ViewBag.v0 = "Category Operations";
            return View();
        }
        [Route("CreateCategory"), HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7135/api/category", createCategoryDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return View();
        }
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7135/api/category?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateCategory/{id}"), HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Category";
            ViewBag.v0 = "Category Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<UpdateCategoryDTO>($"https://localhost:7135/api/category/{id}");
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
        [Route("UpdateCategory/{id}"), HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7135/api/category", updateCategoryDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
