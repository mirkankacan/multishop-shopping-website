using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _CarouselHomeComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselHomeComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var responseValue = await _featureSliderService.GetAllFeatureSlidersAsync(cancellationToken);
            if (responseValue != null)
            {
                return View(responseValue);
            }
            return View();
        }
    }
}