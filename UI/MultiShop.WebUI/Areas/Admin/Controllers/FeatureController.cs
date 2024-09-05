using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Feature List";
            ViewBag.v0 = "Feature Operations";

            var response = await _featureService.GetAllFeaturesAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
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
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO, CancellationToken cancellationToken)
        {
            var response = await _featureService.CreateFeatureAsync(createFeatureDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id, CancellationToken cancellationToken)
        {
            var response = await _featureService.DeleteFeatureAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "Feature", new { Area = "Admin" });
        }

        [Route("UpdateFeature/{id}"), HttpGet]
        public async Task<IActionResult> UpdateFeature(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Feature";
            ViewBag.v0 = "Feature Operations";

            var response = await _featureService.GetByIdFeatureAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateFeature/{id}"), HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO, CancellationToken cancellationToken)
        {
            var response = await _featureService.UpdateFeatureAsync(updateFeatureDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}