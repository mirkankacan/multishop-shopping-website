using MultiShop.Basket.DTOs;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public Task AddBasketItem(BasketItemDTO basketItemDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBasketAsync(string userID)
        {
            await _redisService.GetDb().KeyDeleteAsync(userID);
        }

        public async Task<BasketTotalDTO> GetBasketTotalAsync(string userID)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userID);
            return JsonSerializer.Deserialize<BasketTotalDTO>(existBasket);
        }

        public Task<bool> RemoveBasketItem(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveBasketAsync(BasketTotalDTO basketTotalDTO)
        {
            await _redisService.GetDb().StringSetAsync(key: basketTotalDTO.UserID, value: JsonSerializer.Serialize(basketTotalDTO));
        }
    }
}