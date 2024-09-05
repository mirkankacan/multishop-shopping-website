using MultiShop.DTOLayer.DTOs.CatalogDTOs.ContactDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllContactsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateContactAsync(CreateContactDTO createContactDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateContactAsync(UpdateContactDTO updateContactDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteContactAsync(string id, CancellationToken cancellationToken);

        Task<GetByIdContactDTO> GetByIdContactAsync(string id, CancellationToken cancellationToken);
    }
}