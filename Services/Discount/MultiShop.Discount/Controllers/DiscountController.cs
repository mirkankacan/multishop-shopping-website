using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> CouponList() 
        {
            var discounts = await _discountService.GetAllCouponsAsync();
            return Ok(discounts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var discount = await _discountService.GetByIdCouponAsync(id);
            return Ok(discount);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDTO createCouponDTO)
        {
            await _discountService.CreateCouponAsync(createCouponDTO);
            return Ok("Coupon was created successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Coupon was deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDTO updateCouponDTO)
        {
            await _discountService.UpdateCouponAsync(updateCouponDTO);
            return Ok("Coupon was updated successfully");
        }
    }
}
