using MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("SpecialOffer", createSpecialOfferDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteSpecialOfferAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"SpecialOffer?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDTO>>("SpecialOffer", cancellationToken);
            return response ?? new List<ResultSpecialOfferDTO>();
        }

        public async Task<GetByIdSpecialOfferDTO> GetByIdSpecialOfferAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdSpecialOfferDTO>($"SpecialOffer/{id}", cancellationToken);
            return response ?? new GetByIdSpecialOfferDTO();
        }

        public async Task<HttpResponseMessage> UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("SpecialOffer", updateSpecialOfferDTO, cancellationToken);
            return response;
        }
    }
}