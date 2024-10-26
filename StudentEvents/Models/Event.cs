using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentEvents.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Student Organizer { get; set; }

        public DateOnly Date { get; set; }

        public Student Tasks { get; set; }

        public double Budget { get; set; }
    }
}
