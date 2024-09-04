using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDTO>> GetAllCategoriesAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteCategoryAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id, CancellationToken cancellationToken);
    }
}