using MultiShop.DTOLayer.DTOs.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteOfferDiscountAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdOfferDiscountDTO> GetByIdOfferDiscountAsync(string id, CancellationToken cancellationToken);
    }
}