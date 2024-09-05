using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureSliderDTOs;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Feature Slider List";
            ViewBag.v0 = "Feature Slider Operations";

            var response = await _featureSliderService.GetAllFeatureSlidersAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
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
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDTO createFeatureSliderDTO, CancellationToken cancellationToken)
        {
            createFeatureSliderDTO.Status = false;

            var response = await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id, CancellationToken cancellationToken)
        {
            var response = await _featureSliderService.DeleteFeatureSliderAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "FeatureSlider", new { Area = "Admin" });
        }

        [Route("UpdateFeatureSlider/{id}"), HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Feature Slider";
            ViewBag.v0 = "Feature Slider Operations";

            var response = await _featureSliderService.GetByIdFeatureSliderAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{id}"), HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDTO updateFeatureSliderDTO, CancellationToken cancellationToken)
        {
            var response = await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}