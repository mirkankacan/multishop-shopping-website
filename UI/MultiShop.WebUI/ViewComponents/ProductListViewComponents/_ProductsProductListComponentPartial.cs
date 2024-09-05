using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductsProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductsProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId, CancellationToken cancellationToken)
        {
            var response = await _productService.GetProductsByCategoryIdAsync(categoryId, cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }
    }
}