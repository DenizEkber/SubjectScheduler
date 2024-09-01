
namespace SubjectScheduler.Entity
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public int TimeSlotId { get; set; }
        public int GroupId { get; set; } // Grup ID'si eklendi


        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Group Group { get; set; } // Grup navigasyon özelliği eklendi
    }
}
