using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper,IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSetting.ProductCollection);
            _categoryCollection=database.GetCollection<Category>(_databaseSetting.CategoryCollection);
            _mapper = mapper;
        }


        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
           await  _productCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var valeus = await _productCollection.Find(x => true).ToListAsync();
            foreach(var item in valeus)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();

            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(valeus);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values =_mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductID==updateProductDto.ProductID,values);
        }
    }
}
