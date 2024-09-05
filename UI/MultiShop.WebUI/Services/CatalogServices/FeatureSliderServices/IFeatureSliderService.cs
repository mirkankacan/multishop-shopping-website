using MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteFeatureSliderAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id, CancellationToken cancellationToken);
    }
}