using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _FeatureHomeComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeatureHomeComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await _featureService.GetAllFeaturesAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
    }
}