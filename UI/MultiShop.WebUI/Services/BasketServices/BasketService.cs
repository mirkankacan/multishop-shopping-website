using MultiShop.DTOLayer.DTOs.BasketDTOs;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItemAsync(BasketItemDTO basketItemDTO)
        {
            var values = await GetBasketTotalAsync();
            if (values != null)
            {
                if (!values.BasketItems.Exists(x => x.ProductID == basketItemDTO.ProductID))
                {
                    values.BasketItems.Add(basketItemDTO);
                }
                else
                {
                    values = new BasketTotalDTO();
                    values.BasketItems.Add(basketItemDTO);
                }
            }
            await SaveBasketAsync(values);
        }

        public Task DeleteBasketAsync(string userID)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDTO> GetBasketTotalAsync()
        {
            var responseMessage = await _httpClient.GetAsync("basket");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDTO>();
                return (values);
            }
            return new BasketTotalDTO();
        }

        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
            var values = await GetBasketTotalAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductID == productId);
            if (deletedItem != null)
            {
                var result = values.BasketItems.Remove(deletedItem);
                await SaveBasketAsync(values);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SaveBasketAsync(BasketTotalDTO basketTotalDTO)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDTO>("basket", basketTotalDTO);
        }
    }
}