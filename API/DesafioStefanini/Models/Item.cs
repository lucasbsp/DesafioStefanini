using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesafioStefanini.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DtCreated { get; set; }
        public string? Status { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        [BsonIgnoreIfNull]
        public string? CategoryName { get; set;}
    }
}
