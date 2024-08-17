using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductPreviewDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductPreviewServices
{
    public class ProductPreviewService : IProductPreviewService
    {
        private readonly IMongoCollection<ProductPreview> _productPreviewCollection;
        private readonly IMapper _mapper;

        public ProductPreviewService(IMapper mapper,IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _productPreviewCollection = database.GetCollection<ProductPreview>(_databaseSetting.ProductPreviewCollection);
            _mapper = mapper;
        }

        public async Task CreateProductPreviewAsync(CreateProductPreviewDto productPreviewDto)
        {
            await _productPreviewCollection.InsertOneAsync(_mapper.Map<ProductPreview>(productPreviewDto));
        }

        public async Task DeleteProductPreviewAsync(string id)
        {
            await _productPreviewCollection.DeleteOneAsync(x=>x.ProductPreviewID==id);
        }

        public async Task<List<ResultProductPreviewDto>> GetAllProductPreviewAsync()
        {
            var values = await _productPreviewCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductPreviewDto>>(values);
        }

        public async Task<GetProductPreviewByIdDto> GetByIdProductPreviewAsync(string id)
        {
            var values = await _productPreviewCollection.Find<ProductPreview>(x => x.ProductPreviewID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductPreviewByIdDto>(values);
        }

        public async Task<GetProductPreviewByIdDto> GetProductDetailForProductIdAsync(string id)
        {
            var values = await _productPreviewCollection.Find<ProductPreview>(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductPreviewByIdDto>(values);
        }

        public async Task UpdateProductPreviewAsync(UpdateProductPreviewDto productPreviewDto)
        {
            var values = _mapper.Map<ProductPreview>(productPreviewDto);
            await _productPreviewCollection.FindOneAndReplaceAsync(x => x.ProductPreviewID == productPreviewDto.ProductPreviewID, values);
        }
    }
}
