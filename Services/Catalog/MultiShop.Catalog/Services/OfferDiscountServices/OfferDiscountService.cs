using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.OfferDiscountDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
        private readonly IMapper _mapper;
        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName); // Get into table
            _mapper = mapper;
        }
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            var newOfferDiscount = _mapper.Map<OfferDiscount>(createOfferDiscountDTO);
            await _offerDiscountCollection.InsertOneAsync(newOfferDiscount);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountID == id);
        }

        public async Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync()
        {
            var offerDiscounts = await _offerDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDTO>>(offerDiscounts);
        }

        public async Task<GetByIdOfferDiscountDTO> GetByIdOfferDiscountAsync(string id)
        {
            var offerDiscount = await _offerDiscountCollection.Find(x => x.OfferDiscountID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDTO>(offerDiscount);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            var updatedOfferDiscount = _mapper.Map<OfferDiscount>(updateOfferDiscountDTO);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountID == updateOfferDiscountDTO.OfferDiscountID, updatedOfferDiscount);
        }
    }
}
