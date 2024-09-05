using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet, Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product List";
            ViewBag.v0 = "Product Operations";

            var response = await _productService.GetAllProductsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }

        [Route("ProductListWithCategory"), HttpGet]
        public async Task<IActionResult> ProductListWithCategory(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product List With Category";
            ViewBag.v0 = "Product Operations";

            var response = await _productService.GetProductsWithCategoryAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }

        [Route("CreateProduct"), HttpGet]
        public async Task<IActionResult> CreateProduct(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "New Product";
            ViewBag.v0 = "Product Operations";

            var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
            List<SelectListItem> catergoryValues = (from c in categories
                                                    select new SelectListItem
                                                    {
                                                        Text = c.CategoryName,
                                                        Value = c.CategoryID
                                                    }).ToList();
            ViewBag.CategoryValues = catergoryValues;
            return View();
        }

        [Route("CreateProduct"), HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO, CancellationToken cancellationToken)
        {
            var response = await _productService.CreateProductAsync(createProductDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id, CancellationToken cancellationToken)
        {
            var response = await _productService.DeleteProductAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }

        [Route("UpdateProduct/{id}"), HttpGet]
        public async Task<IActionResult> UpdateProduct(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Category";
            ViewBag.v0 = "Category Operations";

            var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
            List<SelectListItem> catergoryValues = (from c in categories
                                                    select new SelectListItem
                                                    {
                                                        Text = c.CategoryName,
                                                        Value = c.CategoryID
                                                    }).ToList();
            ViewBag.CategoryValues = catergoryValues;
            var response = await _productService.GetByIdProductAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateProduct/{id}"), HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO, CancellationToken cancellationToken)
        {
            var response = await _productService.UpdateProductAsync(updateProductDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}