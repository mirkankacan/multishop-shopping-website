using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.AboutDTOs;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "About List";
            ViewBag.v0 = "About Operations";

            var response = await _aboutService.GetAllAboutsAsync(cancellationToken);
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
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO, CancellationToken cancellationToken)
        {
            var response = await _aboutService.CreateAboutAsync(createAboutDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id, CancellationToken cancellationToken)
        {
            var response = await _aboutService.DeleteAboutAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "About", new { Area = "Admin" });
        }

        [Route("UpdateAbout/{id}"), HttpGet]
        public async Task<IActionResult> UpdateAbout(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update About";
            ViewBag.v0 = "About Operations";

            var response = await _aboutService.GetByIdAboutAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateAbout/{id}"), HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO, CancellationToken cancellationToken)
        {
            var response = await _aboutService.UpdateAboutAsync(updateAboutDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}