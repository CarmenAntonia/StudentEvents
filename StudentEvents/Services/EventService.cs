using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentEvents.Dtos;
using StudentEvents.Models;
using System.Threading.Tasks;

namespace StudentEvents.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _eventsCollection;

        public EventService(IOptions<StudentEventsDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _eventsCollection = mongoDatabase.GetCollection<Event>(
                "Event");
        }

        public async Task<List<Event>> GetAsync() =>
            await _eventsCollection.Find(_ => true).ToListAsync();

        public async Task<Event> GetAsync(string id) =>
            await _eventsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async System.Threading.Tasks.Task CreateAsync(EventDto newEvent)
        {
            Event _event = new Event();
            _event.Title = newEvent.Title;
            _event.Description = newEvent.Description;
            _event.Organizer = newEvent.Organizer;
            _event.Date = newEvent.Date;
            _event.Budget = newEvent.Budget;
            await _eventsCollection.InsertOneAsync(_event);
        }

    }
}
