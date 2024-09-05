using MultiShop.Catalog.DTOs.ProductImageDTOs;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDTO>> GetAllProductImagesAsync();

        Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO);

        Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO);

        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id);

        Task<GetByIdProductImageDTO> GetProductImagesByProductIdAsync(string id);
    }
}