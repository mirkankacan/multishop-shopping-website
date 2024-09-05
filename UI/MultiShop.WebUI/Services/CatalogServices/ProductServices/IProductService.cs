using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateProductAsync(CreateProductDTO createProductDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDTO updateProductDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteProductAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdProductDTO> GetByIdProductAsync(string id, CancellationToken cancellationToken);

        Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync(CancellationToken cancellationToken);

        Task<List<ResultProductWithCategoryDTO>> GetProductsByCategoryIdAsync(string categoryId, CancellationToken cancellationToken);
    }
}