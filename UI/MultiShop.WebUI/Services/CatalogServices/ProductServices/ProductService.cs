using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductAsync(CreateProductDTO createProductDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("product", createProductDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"product?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultProductDTO>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultProductDTO>>("product", cancellationToken);
            return response ?? new List<ResultProductDTO>();
        }

        public async Task<GetByIdProductDTO> GetByIdProductAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdProductDTO>($"product/{id}", cancellationToken);
            return response ?? new GetByIdProductDTO();
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductsByCategoryIdAsync(string categoryId, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDTO>>($"product/ProductListByCategoryId?id={categoryId}", cancellationToken);
            return response ?? new List<ResultProductWithCategoryDTO>();
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDTO>>($"product/ProductListWithCategory", cancellationToken);
            return response ?? new List<ResultProductWithCategoryDTO>();
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDTO updateProductDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("product", updateProductDTO, cancellationToken);
            return response;
        }
    }
}