using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentEvents.Dtos;
using StudentEvents.Models;

namespace StudentEvents.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _studentCollection;

        public StudentService(IOptions<StudentEventsDatabaseSettings> studenteventsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            studenteventsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                studenteventsDatabaseSettings.Value.DatabaseName);

            _studentCollection = mongoDatabase.GetCollection<Student> (
                studenteventsDatabaseSettings.Value.StudentEventsCollectionName);
        }

        public async Task<List<Student>> GetAsync() =>
        await _studentCollection.Find(_ => true).ToListAsync();

        public async Task<Student?> GetAsync(string id) =>
            await _studentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async System.Threading.Tasks.Task CreateAsync(StudentDto newStudent)
        {
            var student = new Student();
            student.Name = newStudent.Name;
            student.Email = newStudent.Email;
            await _studentCollection.InsertOneAsync(student);
        }

        public async System.Threading.Tasks.Task UpdateAsync(string id, Student newStudent) =>
            await _studentCollection.ReplaceOneAsync(x => x.Id == id, newStudent);
    }
}
