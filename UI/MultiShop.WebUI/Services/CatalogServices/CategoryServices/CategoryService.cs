using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("category", createCategoryDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteCategoryAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"category?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultCategoryDTO>>("category", cancellationToken);
            return response ?? new List<ResultCategoryDTO>();
        }

        public async Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdCategoryDTO>($"category/{id}", cancellationToken);
            return response ?? new GetByIdCategoryDTO();
        }

        public async Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("category", updateCategoryDTO, cancellationToken);
            return response;
        }
    }
}