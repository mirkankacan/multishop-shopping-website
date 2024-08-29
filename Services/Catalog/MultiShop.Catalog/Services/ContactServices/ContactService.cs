using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName); // Get into table
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var newContact = _mapper.Map<Contact>(createContactDTO);
            await _contactCollection.InsertOneAsync(newContact);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactID == id);
        }

        public async Task<List<ResultContactDTO>> GetAllContactsAsync()
        {
            var contacts = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDTO>>(contacts);
        }

        public async Task<GetByIdContactDTO> GetByIdContactAsync(string id)
        {
            var contact = await _contactCollection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDTO>(contact);
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            var updatedContact = _mapper.Map<Contact>(updateContactDTO);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == updateContactDTO.ContactID, updatedContact);
        }
    }
}