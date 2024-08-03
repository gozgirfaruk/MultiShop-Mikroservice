using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client =new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSetting.FeatureCollection);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _featureCollection.InsertOneAsync(_mapper.Map<Feature>(createFeatureDto));
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x=>x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetFeatureListAsync()
        {
            var values = await _featureCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values); 
        }

        public async Task<GetFeaureByIdDto> GetFeaureByIdAsync(string id)
        {
            var values = await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeaureByIdDto>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, values);
        }
    }
}
