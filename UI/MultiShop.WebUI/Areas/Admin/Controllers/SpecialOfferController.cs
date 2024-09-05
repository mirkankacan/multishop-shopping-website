using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Special Offer List";
            ViewBag.v0 = "Special Offer Operations";

            var response = await _specialOfferService.GetAllSpecialOffersAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }

        [Route("CreateSpecialOffer"), HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Special Offer";
            ViewBag.v0 = "Special Offer Operations";
            return View();
        }

        [Route("CreateSpecialOffer"), HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO, CancellationToken cancellationToken)
        {
            var response = await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id, CancellationToken cancellationToken)
        {
            var response = await _specialOfferService.DeleteSpecialOfferAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
        }

        [Route("UpdateSpecialOffer/{id}"), HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Special Offer";
            ViewBag.v0 = "Special Offer Operations";

            var response = await _specialOfferService.GetByIdSpecialOfferAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}"), HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO, CancellationToken cancellationToken)
        {
            var response = await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}