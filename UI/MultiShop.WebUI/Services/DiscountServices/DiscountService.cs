using MultiShop.DTOLayer.DTOs.DiscountDTOs;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountByCodeDTO> GetDiscountByCodeAsync(string code)
        {
            var response = await _httpClient.GetFromJsonAsync<GetDiscountByCodeDTO>($"discount/GetCouponByCode/{code}");
            return response;
        }
    }
}