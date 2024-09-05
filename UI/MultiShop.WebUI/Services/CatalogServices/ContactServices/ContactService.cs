using MultiShop.DTOLayer.DTOs.CatalogDTOs.ContactDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateContactAsync(CreateContactDTO createContactDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("Contact", createContactDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteContactAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"Contact?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultContactDTO>> GetAllContactsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultContactDTO>>("Contact", cancellationToken);
            return response ?? new List<ResultContactDTO>();
        }

        public async Task<GetByIdContactDTO> GetByIdContactAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdContactDTO>($"Contact/{id}", cancellationToken);
            return response ?? new GetByIdContactDTO();
        }

        public async Task<HttpResponseMessage> UpdateContactAsync(UpdateContactDTO updateContactDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("Contact", updateContactDTO, cancellationToken);
            return response;
        }
    }
}