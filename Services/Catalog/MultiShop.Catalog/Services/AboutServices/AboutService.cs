using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName); // Get into table
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDTO createAboutDTO)
        {
            var newAbout = _mapper.Map<About>(createAboutDTO);
            await _aboutCollection.InsertOneAsync(newAbout);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutID == id);
        }

        public async Task<List<ResultAboutDTO>> GetAllAboutsAsync()
        {
            var abouts = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDTO>>(abouts);
        }

        public async Task<GetByIdAboutDTO> GetByIdAboutAsync(string id)
        {
            var about = await _aboutCollection.Find(x => x.AboutID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDTO>(about);
        }

        public async Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO)
        {
            var updatedAbout = _mapper.Map<About>(updateAboutDTO);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutID == updateAboutDTO.AboutID, updatedAbout);
        }
    }
}
