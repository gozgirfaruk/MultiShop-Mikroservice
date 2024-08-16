using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper , IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSetting.BrandCollection);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrand)
        {
            await _brandCollection.InsertOneAsync(_mapper.Map<Brand>(createBrand));
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x=>x.BrandId == id);  
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);   
        }

        public async Task<GetBrandByIdDto> GetBrandById(string id)
        {
            var values = await _brandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBrandByIdDto>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrand)
        {
            var values = _mapper.Map<Brand>(updateBrand);
            await _brandCollection.FindOneAndReplaceAsync(x=>x.BrandId==updateBrand.BrandId, values);   
        }
    }
}
