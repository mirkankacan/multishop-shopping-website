using MultiShop.DTOLayer.DTOs.CatalogDTOs.BrandDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateBrandAsync(CreateBrandDTO createBrandDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("Brand", createBrandDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteBrandAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"Brand?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultBrandDTO>> GetAllBrandsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultBrandDTO>>("Brand", cancellationToken);
            return response ?? new List<ResultBrandDTO>();
        }

        public async Task<GetByIdBrandDTO> GetByIdBrandAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdBrandDTO>($"Brand/{id}", cancellationToken);
            return response ?? new GetByIdBrandDTO();
        }

        public async Task<HttpResponseMessage> UpdateBrandAsync(UpdateBrandDTO updateBrandDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("Brand", updateBrandDTO, cancellationToken);
            return response;
        }
    }
}