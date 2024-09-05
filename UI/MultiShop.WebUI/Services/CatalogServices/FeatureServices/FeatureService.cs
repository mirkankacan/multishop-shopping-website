using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateFeatureAsync(CreateFeatureDTO createFeatureDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("Feature", createFeatureDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteFeatureAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"Feature?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultFeatureDTO>> GetAllFeaturesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultFeatureDTO>>("Feature", cancellationToken);
            return response ?? new List<ResultFeatureDTO>();
        }

        public async Task<GetByIdFeatureDTO> GetByIdFeatureAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdFeatureDTO>($"Feature/{id}", cancellationToken);
            return response ?? new GetByIdFeatureDTO();
        }

        public async Task<HttpResponseMessage> UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("Feature", updateFeatureDTO, cancellationToken);
            return response;
        }
    }
}