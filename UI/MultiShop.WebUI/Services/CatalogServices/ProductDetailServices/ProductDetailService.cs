using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("ProductDetail", createProductDetailDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProductDetailAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"ProductDetail?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultProductDetailDTO>>("ProductDetail", cancellationToken);
            return response ?? new List<ResultProductDetailDTO>();
        }

        public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdProductDetailDTO>($"ProductDetail/{id}", cancellationToken);
            return response ?? new GetByIdProductDetailDTO();
        }

        public async Task<GetByIdProductDetailDTO> GetProductDetailByProductId(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdProductDetailDTO>($"ProductDetail/GetProductDetailByProductId/?id={id}", cancellationToken);
            return response ?? new GetByIdProductDetailDTO();
        }

        public async Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("ProductDetail", updateProductDetailDTO, cancellationToken);
            return response;
        }
    }
}