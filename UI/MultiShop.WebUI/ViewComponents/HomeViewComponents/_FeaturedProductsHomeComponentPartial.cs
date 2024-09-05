using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _FeaturedProductsHomeComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeaturedProductsHomeComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var response = await _productService.GetAllProductsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
    }
}