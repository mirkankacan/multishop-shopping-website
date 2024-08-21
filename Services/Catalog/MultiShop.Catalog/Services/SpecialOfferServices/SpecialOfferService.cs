using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName); // Get into table
            _mapper = mapper;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            var newSpecialOffer = _mapper.Map<SpecialOffer>(createSpecialOfferDTO);
            await _specialOfferCollection.InsertOneAsync(newSpecialOffer);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferID == id);
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync()
        {
            var specialOffers = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDTO>>(specialOffers);
        }

        public async Task<GetByIdSpecialOfferDTO> GetByIdSpecialOfferAsync(string id)
        {
            var specialOffer = await _specialOfferCollection.Find(x => x.SpecialOfferID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDTO>(specialOffer);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            var updatedSpecialOffer = _mapper.Map<SpecialOffer>(updateSpecialOfferDTO);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferID == updateSpecialOfferDTO.SpecialOfferID, updatedSpecialOffer);
        }
    }
}
