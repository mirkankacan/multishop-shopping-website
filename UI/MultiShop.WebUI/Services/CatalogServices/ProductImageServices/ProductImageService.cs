using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductImageDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductImageAsync(CreateProductImageDTO createProductImageDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("ProductImage", createProductImageDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProductImageAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"ProductImage?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultProductImageDTO>> GetAllProductImagesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultProductImageDTO>>("ProductImage", cancellationToken);
            return response ?? new List<ResultProductImageDTO>();
        }

        public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdProductImageDTO>($"ProductImage/{id}", cancellationToken);
            return response ?? new GetByIdProductImageDTO();
        }

        public async Task<HttpResponseMessage> UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("ProductImage", updateProductImageDTO, cancellationToken);
            return response;
        }
    }
}