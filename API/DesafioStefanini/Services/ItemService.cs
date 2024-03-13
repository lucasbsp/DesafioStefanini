using MongoDB.Driver;
using DesafioStefanini.Models;
using Microsoft.Extensions.Options;
using ZstdSharp.Unsafe;
using MongoDB.Bson;
using System.Runtime;

namespace DesafioStefanini.Services
{
    public class ItemService : IItemService
    {
        private readonly IMongoCollection<Item> _itemCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;
        public ItemService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _itemCollection = mongoDatabase.GetCollection<Item>(dbSettings.Value.ItemsCollectionName);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var pipeline = new BsonDocument[]
            {
              new BsonDocument("$lookup", new BsonDocument
              {
                { "from", "CategoryCollection" },
                { "localField", "CategoryId" },
                { "foreignField", "_id" },
                { "as", "item_category" }
              }),
              new BsonDocument("$unwind", "$item_category"),
              new BsonDocument("$project", new BsonDocument
              {
                { "_id", 1 },
                { "Title", 1 },
                { "Description", 1 },
                { "DtCreated", 1 },
                { "Status", 1 },
                { "CategoryId", 1 },
                { "CategoryName", "$item_category.CategoryName" }
              })
            };

            var results = await _itemCollection.Aggregate<Item>(pipeline).ToListAsync();

            return results;
        }

        public async Task<Item> GetById(string id) =>
            await _itemCollection.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Item item) =>
            await _itemCollection.InsertOneAsync(item);

        public async Task UpdateAsync(string id, Item item) =>
            await _itemCollection.ReplaceOneAsync(i => i.Id == id, item);

        public async Task DeleteAsync(string id) =>
            await _itemCollection.DeleteOneAsync(i => i.Id == id);
    }
}
