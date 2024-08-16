using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        public ProductImageService(IMapper mapper,IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSetting.ProductImageCollection);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto productImageDto)
        {
            await _productImageCollection.InsertOneAsync(_mapper.Map<ProductImage>(productImageDto));
        }

        public async Task DeleteProductImageAsync(string id)
        {
          await  _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productId)
        {
            var values = await _productImageCollection.Find<ProductImage>(x => x.ProductID == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto productImageDto)
        {
            var values = _mapper.Map<ProductImage>(productImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == productImageDto.ProductImageID, values);
        }
    }
}
