using MongoDB.Driver;
using DesafioStefanini.Models;
using Microsoft.Extensions.Options;

namespace DesafioStefanini.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;
        public CategoryService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _categoryCollection = mongoDatabase.GetCollection<Category>(dbSettings.Value.CategoriesCollectionName);
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => 
            await _categoryCollection.Find(_ => true).ToListAsync();

        public async Task<Category> GetById(string id) =>
            await _categoryCollection.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category category) =>
            await _categoryCollection.InsertOneAsync(category);

        public async Task UpdateAsync(string id, Category category) =>
            await _categoryCollection.ReplaceOneAsync(c => c.Id == id, category);

        public async Task DeleteAsync(string id) =>
            await _categoryCollection.DeleteOneAsync(c => c.Id == id);
    }
}
