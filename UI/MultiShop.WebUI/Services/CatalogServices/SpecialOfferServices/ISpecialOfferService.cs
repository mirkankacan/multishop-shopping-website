using MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteSpecialOfferAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdSpecialOfferDTO> GetByIdSpecialOfferAsync(string id, CancellationToken cancellationToken);
    }
}