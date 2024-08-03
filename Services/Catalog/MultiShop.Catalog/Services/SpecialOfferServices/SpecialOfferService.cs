using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOffierDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using ZstdSharp.Unsafe;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _offerCollection;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _offerCollection = database.GetCollection<SpecialOffer>(_databaseSetting.SpecialOfferCollection);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createOfferDto)
        {
           await _offerCollection.InsertOneAsync(_mapper.Map<SpecialOffer>(createOfferDto));
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _offerCollection.DeleteOneAsync(x=>x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _offerCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id)
        {
            var values = await _offerCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSpecialOfferByIdDto>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateOfferDto);
            await _offerCollection.FindOneAndReplaceAsync(x=>x.SpecialOfferId==updateOfferDto.SpecialOfferId, values);
        }
    }
}
