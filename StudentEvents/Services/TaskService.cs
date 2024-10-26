using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentEvents.Dtos;
using StudentEvents.Models;

namespace StudentEvents.Services
{
    public class TaskService
    {
        private readonly IMongoCollection<Models.Task> _tasksCollection;

        public TaskService(IOptions<StudentEventsDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _tasksCollection = mongoDatabase.GetCollection<Models.Task>(
                "Task");
        }

        public async Task<List<Models.Task>> GetAsync() =>
            await _tasksCollection.Find(_ => true).ToListAsync();

        public async Task<Models.Task?> GetAsync(string id) =>
            await _tasksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async System.Threading.Tasks.Task CreateAsync(TaskDto newTask)
        {
            Models.Task task = new Models.Task();
            task.Description = newTask.Description;
            task.Students = newTask.Students;
            task.DueDate = newTask.DueDate;
            task.Price = newTask.Price;
            task.Event = newTask.Event;
            await _tasksCollection.InsertOneAsync(task);
        }


    }
}
