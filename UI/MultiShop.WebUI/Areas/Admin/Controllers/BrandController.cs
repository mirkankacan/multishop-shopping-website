using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.BrandDTOs;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Brand List";
            ViewBag.v0 = "Brand Operations";

            var response = await _brandService.GetAllBrandsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
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
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO, CancellationToken cancellationToken)
        {
            var response = await _brandService.CreateBrandAsync(createBrandDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id, CancellationToken cancellationToken)
        {
            var response = await _brandService.DeleteBrandAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }

        [Route("UpdateBrand/{id}"), HttpGet]
        public async Task<IActionResult> UpdateBrand(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Brand";
            ViewBag.v0 = "Brand Operations";

            var response = await _brandService.GetByIdBrandAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateBrand/{id}"), HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO, CancellationToken cancellationToken)
        {
            var response = await _brandService.UpdateBrandAsync(updateBrandDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
    }
}