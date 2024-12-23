using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDTO>> GetAllCouponsAsync();

        Task CreateCouponAsync(CreateCouponDTO createCouponDTO);

        Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO);

        Task DeleteCouponAsync(int id);

        Task<GetByIdCouponDTO> GetByIdCouponAsync(int id);

        Task<GetByIdCouponDTO> GetCouponByCodeAsync(string code);
    }
}