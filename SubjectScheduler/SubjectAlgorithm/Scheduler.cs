using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Context;
using SubjectScheduler.Entity;

namespace SubjectScheduler.SubjectAlgorithm
{
    public class Scheduler
    {
        private readonly UniversityContext _context;

        public Scheduler(UniversityContext context)
        {
            _context = context;
        }

        public void GenerateWeeklySchedule()
        {
            var groups = _context.Groups.Include(g => g.Courses).ToList();
            var teachers = _context.Teachers.Include(t => t.AvailableTimes).ToList();
            var classrooms = _context.Classrooms.ToList();
            var timeSlots = _context.TimeSlots.ToList();

            foreach (var group in groups)
            {
                foreach (var course in group.Courses)
                {
                    int remainingHours = course.TotalHours;
                    var availableTimeSlots = new List<TimeSlot>(timeSlots);

                    while (remainingHours > 0)
                    {
                        var suitableTeachers = teachers.Where(t => CanTeachCourse(t, course)).ToList();
                        var suitableClassrooms = classrooms.Where(c => IsClassroomSuitable(c, course)).ToList();

                        var suitableTimeSlots = availableTimeSlots
                            .Where(ts => IsTimeSlotSuitable(group, ts) && IsSlotAvailableForGroup(group, ts))
                            .ToList();

                        bool slotFound = false;
                        foreach (var timeSlot in suitableTimeSlots)
                        {
                            foreach (var teacher in suitableTeachers)
                            {
                                foreach (var classroom in suitableClassrooms)
                                {
                                    if (IsSlotAvailable(teacher, classroom, timeSlot))
                                    {
                                        var schedule = new Schedule
                                        {
                                            GroupId = group.GroupId,
                                            CourseId = course.CourseId,
                                            TeacherId = teacher.TeacherId,
                                            ClassroomId = classroom.ClassroomId,
                                            TimeSlotId = timeSlot.TimeSlotId
                                        };

                                        _context.Schedules.Add(schedule);
                                        _context.SaveChanges();

                                        remainingHours -= (int)(timeSlot.EndTime - timeSlot.StartTime).TotalHours;

                                        // Zaman dilimini diğer dersler için kullanılamaz hale getir
                                        availableTimeSlots.Remove(timeSlot);
                                        slotFound = true;
                                        break;
                                    }
                                }
                                if (slotFound) break;
                            }
                            if (slotFound) break;
                        }

                        // Eğer uygun bir zaman dilimi bulunamazsa döngüyü durdur
                        if (!slotFound) break;
                    }
                }
            }

            PrintSchedule(); // Program oluşturulduktan sonra yazdır
        }


        private void PrintSchedule()
        {
            var schedules = _context.Schedules
                .Include(s => s.Group)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.Classroom)
                .Include(s => s.TimeSlot)
                .ToList();

            Console.WriteLine("Haftalık Ders Programı:");
            Console.WriteLine(new string('-', 50));

            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Grup: {schedule.Group.GroupName}");
                Console.WriteLine($"Ders: {schedule.Course.CourseName}");
                Console.WriteLine($"Öğretmen: {schedule.Teacher.TeacherName}");
                Console.WriteLine($"Sınıf: {schedule.Classroom.Location}");
                Console.WriteLine($"Zaman: {schedule.TimeSlot.DayOfWeek} {schedule.TimeSlot.StartTime} - {schedule.TimeSlot.EndTime}");
                Console.WriteLine(new string('-', 50));
            }
        }

        private bool CanTeachCourse(Teacher teacher, Course course)
        {
            // Öğretmenin bu dersi verebilme yeteneği kontrolü
            return true; // Basitlik için her öğretmen her dersi verebilir varsayıyoruz
        }

        private bool IsClassroomSuitable(Classroom classroom, Course course)
        {
            // Dersin türüne göre sınıfın uygun olup olmadığını kontrol et
            // Örneğin, bilgisayar dersleri için bilgisayar laboratuvarı gerekli olabilir
            return true;
        }

        private bool IsTimeSlotSuitable(Group group, TimeSlot timeSlot)
        {
            // Öğrenci grubunun okula gelme saatlerine göre zaman diliminin uygun olup olmadığını kontrol et
            if (group.CourseYear == 1 || group.CourseYear == 3)
            {
                return timeSlot.StartTime.Hours >= 12; // 1. ve 3. sınıflar öğleden sonra gelir
            }
            else
            {
                return timeSlot.StartTime.Hours < 12; // 2. ve 4. sınıflar sabah gelir
            }
        }

        private bool IsSlotAvailableForGroup(Group group, TimeSlot timeSlot)
        {
            // Öğrenci grubunun o zaman diliminde başka bir dersi olup olmadığını kontrol et
            return !_context.Schedules.Any(s => s.GroupId == group.GroupId && s.TimeSlotId == timeSlot.TimeSlotId);
        }

        private bool IsSlotAvailable(Teacher teacher, Classroom classroom, TimeSlot timeSlot)
        {
            // Öğretmenin o zaman diliminde başka bir dersi olup olmadığını kontrol et
            var teacherHasConflict = _context.Schedules.Any(s => s.TeacherId == teacher.TeacherId && s.TimeSlotId == timeSlot.TimeSlotId);

            // Sınıfta o zaman diliminde başka bir ders olup olmadığını kontrol et
            var classroomHasConflict = _context.Schedules.Any(s => s.ClassroomId == classroom.ClassroomId && s.TimeSlotId == timeSlot.TimeSlotId);

            return !teacherHasConflict && !classroomHasConflict;
        }
    }
}
