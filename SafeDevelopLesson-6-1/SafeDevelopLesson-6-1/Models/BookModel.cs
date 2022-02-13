using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SafeDevelopLesson_6_1.Models
{
    public class BookModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Autor { get; set; }
    }
}
