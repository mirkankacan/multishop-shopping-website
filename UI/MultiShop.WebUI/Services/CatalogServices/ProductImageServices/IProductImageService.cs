using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductImageDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDTO>> GetAllProductImagesAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateProductImageAsync(CreateProductImageDTO createProductImageDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteProductImageAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdProductImageDTO> GetProductImagesByProductIdAsync(string id, CancellationToken cancellationToken);
    }
}