using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper,IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.ConnectionString);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSetting.ProductDetailCollectionName);
            _mapper = mapper;
        }

        
        public async Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto)
        {
            await _productDetailCollection.InsertOneAsync(_mapper.Map<ProductDetail>(productDetailDto));
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(productDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == productDetailDto.ProductDetailID, values);
        }
    }
}
