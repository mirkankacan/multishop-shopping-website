using MultiShop.DTOLayer.DTOs.CatalogDTOs.AboutDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateAboutAsync(CreateAboutDTO createAboutDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("About", createAboutDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAboutAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"About?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultAboutDTO>> GetAllAboutsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultAboutDTO>>("About", cancellationToken);
            return response ?? new List<ResultAboutDTO>();
        }

        public async Task<GetByIdAboutDTO> GetByIdAboutAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdAboutDTO>($"About/{id}", cancellationToken);
            return response ?? new GetByIdAboutDTO();
        }

        public async Task<HttpResponseMessage> UpdateAboutAsync(UpdateAboutDTO updateAboutDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("About", updateAboutDTO, cancellationToken);
            return response;
        }
    }
}