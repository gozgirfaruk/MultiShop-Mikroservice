using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _ofDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _ofDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSetting.OfferDiscountCollection);
            _mapper = mapper;
        }
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscount)
        {
           await _ofDiscountCollection.InsertOneAsync(_mapper.Map<OfferDiscount>(createOfferDiscount));
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
           await _ofDiscountCollection.DeleteOneAsync(x=>x.OfferDiscountId == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _ofDiscountCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<GetOfferDiscountById> GetOfferDiscountByIdAsync(string id)
        {
            var values = await _ofDiscountCollection.Find(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetOfferDiscountById>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscount)
        {
            var values = _mapper.Map<OfferDiscount>(updateOfferDiscount);
            await _ofDiscountCollection.FindOneAndReplaceAsync(x=>x.OfferDiscountId==updateOfferDiscount.OfferDiscountId,values);
        }
    }
}
