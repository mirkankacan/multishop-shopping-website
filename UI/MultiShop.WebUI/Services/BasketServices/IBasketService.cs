using MultiShop.DTOLayer.DTOs.BasketDTOs;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasketTotalAsync();

        Task SaveBasketAsync(BasketTotalDTO basketTotalDTO);

        Task DeleteBasketAsync(string userID);

        Task AddBasketItemAsync(BasketItemDTO basketItemDTO);

        Task<bool> RemoveBasketItemAsync(string productId);
    }
}