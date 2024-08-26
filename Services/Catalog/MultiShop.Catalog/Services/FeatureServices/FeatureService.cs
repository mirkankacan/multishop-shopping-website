using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName); // Get into table
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO)
        {
            var newFeature = _mapper.Map<Feature>(createFeatureDTO);
            await _featureCollection.InsertOneAsync(newFeature);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDTO>> GetAllFeaturesAsync()
        {
            var features = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDTO>>(features);
        }

        public async Task<GetByIdFeatureDTO> GetByIdFeatureAsync(string id)
        {
            var feature = await _featureCollection.Find(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDTO>(feature);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO)
        {
            var updatedFeature = _mapper.Map<Feature>(updateFeatureDTO);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDTO.FeatureID, updatedFeature);
        }
    }
}
