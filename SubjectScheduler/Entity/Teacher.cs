
namespace SubjectScheduler.Entity
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public ICollection<TimeSlot> AvailableTimes { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
