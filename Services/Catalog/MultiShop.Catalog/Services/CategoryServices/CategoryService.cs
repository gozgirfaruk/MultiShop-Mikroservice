using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSetting _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSetting.CategoryCollection);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(categoryDto));
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return  _mapper.Map<List<ResultCategoryDto>>(values);

        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var values = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID==categoryDto.CategoryID, values);
        }
    }
}
