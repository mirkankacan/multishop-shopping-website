using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _productImageService.GetProductImagesByProductIdAsync(productId, cancellationToken);
                if (response != null)
                {
                    return View(response);
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}