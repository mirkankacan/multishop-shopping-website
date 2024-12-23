using MultiShop.DTOLayer.DTOs.DiscountDTOs;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountByCodeDTO> GetDiscountByCodeAsync(string code);
    }
}