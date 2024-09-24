using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.DTOs;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCartAsync()
        {
            var values = await _basketService.GetBasketTotalAsync(_loginService.GetUserID);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveShoppingCartAsync(BasketTotalDTO basketTotalDTO)
        {
            basketTotalDTO.UserID = _loginService.GetUserID;
            await _basketService.SaveBasketAsync(basketTotalDTO);
            return Ok("Changes in the shopping cart have been saved");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartAsync()
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserID);
            return Ok("Items in the shopping cart have been deleted");
        }
    }
}
