using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DesafioStefanini.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public string? CategoryName { get; set; }
    }
}
