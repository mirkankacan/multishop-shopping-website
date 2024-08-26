using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName); // Get into table
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDTO createBrandDTO)
        {
            var newBrand = _mapper.Map<Brand>(createBrandDTO);
            await _brandCollection.InsertOneAsync(newBrand);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDTO>> GetAllBrandsAsync()
        {
            var brands = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDTO>>(brands);
        }

        public async Task<GetByIdBrandDTO> GetByIdBrandAsync(string id)
        {
            var Brand = await _brandCollection.Find(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDTO>(Brand);
        }

        public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO)
        {
            var updatedBrand = _mapper.Map<Brand>(updateBrandDTO);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDTO.BrandID, updatedBrand);
        }
    }
}
