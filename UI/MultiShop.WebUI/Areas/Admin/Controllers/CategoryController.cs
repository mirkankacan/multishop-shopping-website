using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Category List";
            ViewBag.v0 = "Category Operations";
            var response = await _categoryService.GetAllCategoriesAsync(cancellationToken);
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
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO, CancellationToken cancellationToken)
        {
            var response = await _categoryService.CreateCategoryAsync(createCategoryDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id, CancellationToken cancellationToken)
        {
            var response = await _categoryService.DeleteCategoryAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [Route("UpdateCategory/{id}"), HttpGet]
        public async Task<IActionResult> UpdateCategory(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Category";
            ViewBag.v0 = "Category Operations";

            var response = await _categoryService.GetByIdCategoryAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateCategory/{id}"), HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var response = await _categoryService.UpdateCategoryAsync(updateCategoryDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}