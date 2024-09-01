
namespace SubjectScheduler.Entity
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
