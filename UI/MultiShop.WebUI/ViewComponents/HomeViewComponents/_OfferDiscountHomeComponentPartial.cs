using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _OfferDiscountHomeComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountHomeComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await _offerDiscountService.GetAllOfferDiscountsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
    }
}