using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper,IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _featureSliderCollection=database.GetCollection<FeatureSlider>(_databaseSetting.FeatureSliderCollection);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSlider)
        {
            await _featureSliderCollection.InsertOneAsync(_mapper.Map<FeatureSlider>(createFeatureSlider));
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
           await _featureSliderCollection.DeleteOneAsync(x=>x.FeatureSliderId == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
        {
            var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureSliderByIdDto>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSlider)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSlider);
            await _featureSliderCollection.FindOneAndReplaceAsync(x=>x.FeatureSliderId==updateFeatureSlider.FeatureSliderId, values);
        }
    }
}
