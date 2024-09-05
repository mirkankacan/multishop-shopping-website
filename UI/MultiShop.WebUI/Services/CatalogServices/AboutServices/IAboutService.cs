using MultiShop.DTOLayer.DTOs.CatalogDTOs.AboutDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDTO>> GetAllAboutsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateAboutAsync(CreateAboutDTO createAboutDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateAboutAsync(UpdateAboutDTO updateAboutDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteAboutAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdAboutDTO> GetByIdAboutAsync(string id, CancellationToken cancellationToken);
    }
}