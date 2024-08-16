using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<About> _aboutCollection;
        public AboutService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSetting.AboutCollection);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _aboutCollection.InsertOneAsync(_mapper.Map<About>(createAboutDto));  
        }

        public async Task<GetAboutByIdDto> GetAboutByIdAsync(string id)
        {
            var values = await _aboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetAboutByIdDto>(values);
        }

        public async Task<List<ResultAboutDto>> GetAboutListAsync()
        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x=>x.AboutId==updateAboutDto.AboutId, values);
        }
    }
}
