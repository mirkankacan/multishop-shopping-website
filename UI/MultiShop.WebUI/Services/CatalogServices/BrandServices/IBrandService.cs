using MultiShop.DTOLayer.DTOs.CatalogDTOs.BrandDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDTO>> GetAllBrandsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateBrandAsync(CreateBrandDTO createBrandDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateBrandAsync(UpdateBrandDTO updateBrandDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteBrandAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdBrandDTO> GetByIdBrandAsync(string id, CancellationToken cancellationToken);
    }
}