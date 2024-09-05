using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.OfferDiscountDTOs;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Offer Discount List";
            ViewBag.v0 = "Offer Discount Operations";

            var response = await _offerDiscountService.GetAllOfferDiscountsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }

        [Route("CreateOfferDiscount"), HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "New Offer Discount";
            ViewBag.v0 = "Offer Discount Operations";
            return View();
        }

        [Route("CreateOfferDiscount"), HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDTO createOfferDiscountDTO, CancellationToken cancellationToken)
        {
            var response = await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id, CancellationToken cancellationToken)
        {
            var response = await _offerDiscountService.DeleteOfferDiscountAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
        }

        [Route("UpdateOfferDiscount/{id}"), HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Offer Discount";
            ViewBag.v0 = "Offer Discount Operations";

            var response = await _offerDiscountService.GetByIdOfferDiscountAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}"), HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDTO updateOfferDiscountDTO, CancellationToken cancellationToken)
        {
            var response = await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
    }
}