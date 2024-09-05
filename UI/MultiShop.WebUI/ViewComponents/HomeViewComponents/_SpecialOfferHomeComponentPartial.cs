using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _SpecialOfferHomeComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferHomeComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await _specialOfferService.GetAllSpecialOffersAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
    }
}