using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.BasketDTOs;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasketTotalAsync();
            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string productId, CancellationToken cancellationToken)
        {
            var values = await _productService.GetByIdProductAsync(productId, cancellationToken);
            var items = new BasketItemDTO
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1
            };
            await _basketService.AddBasketItemAsync(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItemAsync(productId);
            return RedirectToAction("Index");
        }
    }
}