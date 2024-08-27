using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // Connection.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Get into database.
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName); // Get into table.
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            var newProductDetail = _mapper.Map<ProductDetail>(createProductDetailDTO);
            await _productDetailCollection.InsertOneAsync(newProductDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailsAsync()
        {
            var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDTO>>(productDetails);
        }

        public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDTO>(productDetail);
        }

        public async Task<GetByIdProductDetailDTO> GetProductDetailByProductId(string id)
        {
            var productDetail = await _productDetailCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDTO>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var updatedProductDetail = _mapper.Map<ProductDetail>(updateProductDetailDTO);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDTO.ProductDetailID, updatedProductDetail);
        }
    }
}