using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName); // Get into table
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            var newFeatureSlider = _mapper.Map<FeatureSlider>(createFeatureSliderDTO);
            await _featureSliderCollection.InsertOneAsync(newFeatureSlider);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDTO>> GetAllFeatureSliderAsync()
        {
            var categories = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDTO>>(categories);
        }

        public async Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id)
        {
            var FeatureSlider = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDTO>(FeatureSlider);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            var updatedFeatureSlider = _mapper.Map<FeatureSlider>(updateFeatureSliderDTO);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == updateFeatureSliderDTO.FeatureSliderID, updatedFeatureSlider);
        }
    }
}

