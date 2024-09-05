using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _VendorHomeComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendorHomeComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await _brandService.GetAllBrandsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
    }
}