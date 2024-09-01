
namespace SubjectScheduler.Entity
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int CourseYear { get; set; } // Grubun okuduğu yıl, 1, 2, 3, 4 gibi
        
        public ICollection<Course> Courses { get; set; } // Grubun aldığı dersler
        public ICollection<Schedule> Schedules { get; set; } // Grup için programlar
    }
}
