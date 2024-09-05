using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("FeatureSlider", createFeatureSliderDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteFeatureSliderAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"FeatureSlider?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDTO>>("FeatureSlider", cancellationToken);
            return response ?? new List<ResultFeatureSliderDTO>();
        }

        public async Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdFeatureSliderDTO>($"FeatureSlider/{id}", cancellationToken);
            return response ?? new GetByIdFeatureSliderDTO();
        }

        public async Task<HttpResponseMessage> UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("FeatureSlider", updateFeatureSliderDTO, cancellationToken);
            return response;
        }
    }
}