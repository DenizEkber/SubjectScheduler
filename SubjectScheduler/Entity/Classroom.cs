
namespace SubjectScheduler.Entity
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
