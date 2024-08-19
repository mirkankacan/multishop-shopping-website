using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var newProduct = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(newProduct);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);

            //      FindOneAndDeleteAsync:

            // This method is used to find a single document matching a specified filter, delete it, and return the deleted document.
            // It performs two operations: finding a document and then deleting it.
            // It is useful when you need to delete a document and also want to retrieve its contents before deletion.
            //            ///////////////////////////////////////////////////
            //      DeleteOneAsync:

            // This method is used to delete a single document that matches a specified filter.
            // It only performs the deletion operation and does not return the deleted document.
            // It is straightforward and efficient when you just need to delete a document without retrieving its contents.
        }

        public async Task<List<ResultProductDTO>> GetAllProductsAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDTO>>(products);
        }

        public async Task<GetByIdProductDTO> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDTO>(product);
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDTO>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var updatedProduct = _mapper.Map<Product>(updateProductDTO);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDTO.ProductID, updatedProduct);
        }
    }
}
