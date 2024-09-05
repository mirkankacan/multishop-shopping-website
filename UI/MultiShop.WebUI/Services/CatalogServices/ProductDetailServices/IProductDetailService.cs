using MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDTO>> GetAllProductDetailsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteProductDetailAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdProductDetailDTO> GetProductDetailByProductId(string id, CancellationToken cancellationToken);
    }
}