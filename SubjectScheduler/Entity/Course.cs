
namespace SubjectScheduler.Entity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TotalHours { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
