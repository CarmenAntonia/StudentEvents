using StudentEvents.Models;

namespace StudentEvents.Dtos
{
    public class TaskDto
    {
        public string Description { get; set; }

        public List<Student> Students { get; set; }

        public DateOnly DueDate { get; set; }

        public double Price { get; set; }

        public Event Event { get; set; }
    }
}
