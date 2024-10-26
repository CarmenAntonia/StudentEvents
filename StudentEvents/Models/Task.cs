using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentEvents.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Description { get; set; }

        public List<Student> Students { get; set; }

        public DateOnly DueDate { get; set; }

        public double Price { get; set; }
    }
}
