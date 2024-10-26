namespace StudentEvents.Models
{
    public class StudentEventsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StudentEventsCollectionName { get; set; } = null!;
    }
}
