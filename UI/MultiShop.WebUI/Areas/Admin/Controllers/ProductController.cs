using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet, Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product List";
            ViewBag.v0 = "Product Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultProductDTO>>("https://localhost:7135/api/product");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
        [Route("ProductListWithCategory"), HttpGet]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product List With Category";
            ViewBag.v0 = "Product Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetFromJsonAsync<List<ResultProductWithCategoryDTO>>("https://localhost:7135/api/product/productlistwithcategory");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }

            return View();
        }
        [Route("CreateProduct"), HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "New Product";
            ViewBag.v0 = "Product Operations";
            var client = _httpClientFactory.CreateClient();
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("https://localhost:7135/api/category");
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
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.PostAsJsonAsync("https://localhost:7135/api/product", createProductDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7135/api/product?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateProduct/{id}"), HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Category";
            ViewBag.v0 = "Category Operations";

            var client = _httpClientFactory.CreateClient();
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("https://localhost:7135/api/category");
            List<SelectListItem> catergoryValues = (from c in categories
                                                    select new SelectListItem
                                                    {
                                                        Text = c.CategoryName,
                                                        Value = c.CategoryID
                                                    }).ToList();
            ViewBag.CategoryValues = catergoryValues;
            var responseMessage = await client.GetFromJsonAsync<UpdateProductDTO>($"https://localhost:7135/api/product/{id}");
            if (responseMessage != null)
            {
                return View(responseMessage);
            }
            return View();
        }
        [Route("UpdateProduct/{id}"), HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsJsonAsync("https://localhost:7135/api/product", updateProductDTO);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
