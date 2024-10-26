using StudentEvents.Models;

namespace StudentEvents.Dtos
{
    public class EventDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Student Organizer { get; set; }

        public DateOnly Date { get; set; }

        public double Budget { get; set; }
    }
}
