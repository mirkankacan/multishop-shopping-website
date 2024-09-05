using MultiShop.DTOLayer.DTOs.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("OfferDiscount", createOfferDiscountDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteOfferDiscountAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"OfferDiscount?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDTO>>("OfferDiscount", cancellationToken);
            return response ?? new List<ResultOfferDiscountDTO>();
        }

        public async Task<GetByIdOfferDiscountDTO> GetByIdOfferDiscountAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdOfferDiscountDTO>($"OfferDiscount/{id}", cancellationToken);
            return response ?? new GetByIdOfferDiscountDTO();
        }

        public async Task<HttpResponseMessage> UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("OfferDiscount", updateOfferDiscountDTO, cancellationToken);
            return response;
        }
    }
}