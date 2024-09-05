using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDTO>> GetAllFeaturesAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateFeatureAsync(CreateFeatureDTO createFeatureDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteFeatureAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdFeatureDTO> GetByIdFeatureAsync(string id, CancellationToken cancellationToken);
    }
}