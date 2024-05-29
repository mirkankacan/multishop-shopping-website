using MultiShop.Basket.DTOs;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasketTotalAsync(string userID);
        Task SaveBasketAsync(BasketTotalDTO basketTotalDTO);
        Task DeleteBasketAsync(string userID);
    }
}
