using SubjectScheduler.Context;
using SubjectScheduler.Entity;


namespace SubjectScheduler.TestDataGenerator
{
    public class DataGenerator
    {
        public static void Initialize(UniversityContext context)
        {
            if (context.Departments.Any()) return; // Veritabanı doluysa işlem yapma

            // Bölümler
            var departments = new List<Department>
        {
            new Department { DepartmentName = "Computer Science" },
            new Department { DepartmentName = "Mathematics" },
            new Department { DepartmentName = "Physics" },
            new Department { DepartmentName = "Chemistry" },
            new Department { DepartmentName = "Biology" },
            new Department { DepartmentName = "History" },
            new Department { DepartmentName = "Literature" },
            new Department { DepartmentName = "Philosophy" },
            new Department { DepartmentName = "Economics" },
            new Department { DepartmentName = "Sociology" }
        };
            context.Departments.AddRange(departments);

            // Dersler
            var courses = new List<Course>
        {
            new Course { CourseName = "Algorithms", TotalHours = 40, Department = departments[0] },
            new Course { CourseName = "Data Structures", TotalHours = 35, Department = departments[0] },
            new Course { CourseName = "Linear Algebra", TotalHours = 45, Department = departments[1] },
            new Course { CourseName = "Quantum Mechanics", TotalHours = 50, Department = departments[2] },
            new Course { CourseName = "Organic Chemistry", TotalHours = 42, Department = departments[3] },
            new Course { CourseName = "Genetics", TotalHours = 38, Department = departments[4] },
            new Course { CourseName = "World History", TotalHours = 40, Department = departments[5] },
            new Course { CourseName = "Poetry", TotalHours = 30, Department = departments[6] },
            new Course { CourseName = "Ethics", TotalHours = 25, Department = departments[7] },
            new Course { CourseName = "Microeconomics", TotalHours = 48, Department = departments[8] }
        };
            context.Courses.AddRange(courses);

            // Gruplar
            var groups = new List<Group>
        {
            new Group { GroupName = "Group A", CourseYear = 1, Courses = new List<Course> { courses[0], courses[2] } },
            new Group { GroupName = "Group B", CourseYear = 2, Courses = new List<Course> { courses[1], courses[3] } },
            new Group { GroupName = "Group C", CourseYear = 3, Courses = new List<Course> { courses[4], courses[5] } },
            new Group { GroupName = "Group D", CourseYear = 4, Courses = new List<Course> { courses[6], courses[7] } },
            new Group { GroupName = "Group E", CourseYear = 1, Courses = new List<Course> { courses[8], courses[9] } },
            new Group { GroupName = "Group F", CourseYear = 2, Courses = new List<Course> { courses[0], courses[4] } },
            new Group { GroupName = "Group G", CourseYear = 3, Courses = new List<Course> { courses[2], courses[6] } },
            new Group { GroupName = "Group H", CourseYear = 4, Courses = new List<Course> { courses[1], courses[3] } },
            new Group { GroupName = "Group I", CourseYear = 1, Courses = new List<Course> { courses[5], courses[7] } },
            new Group { GroupName = "Group J", CourseYear = 2, Courses = new List<Course> { courses[8], courses[9] } }
        };
            context.Groups.AddRange(groups);

            // Sınıflar
            var classrooms = new List<Classroom>
        {
            new Classroom { Capacity = 30, Location = "Building A - Room 101" },
            new Classroom { Capacity = 25, Location = "Building A - Room 102" },
            new Classroom { Capacity = 35, Location = "Building B - Room 201" },
            new Classroom { Capacity = 40, Location = "Building B - Room 202" },
            new Classroom { Capacity = 50, Location = "Building C - Room 301" },
            new Classroom { Capacity = 20, Location = "Building C - Room 302" },
            new Classroom { Capacity = 30, Location = "Building D - Room 401" },
            new Classroom { Capacity = 45, Location = "Building D - Room 402" },
            new Classroom { Capacity = 28, Location = "Building E - Room 501" },
            new Classroom { Capacity = 32, Location = "Building E - Room 502" }
        };
            context.Classrooms.AddRange(classrooms);

            // Öğretmenler
            var teachers = new List<Teacher>
        {
            new Teacher { TeacherName = "John Doe" },
            new Teacher { TeacherName = "Jane Smith" },
            new Teacher { TeacherName = "Emily Johnson" },
            new Teacher { TeacherName = "Michael Brown" },
            new Teacher { TeacherName = "Sarah Davis" },
            new Teacher { TeacherName = "David Wilson" },
            new Teacher { TeacherName = "Daniel Anderson" },
            new Teacher { TeacherName = "Laura Martinez" },
            new Teacher { TeacherName = "Robert Taylor" },
            new Teacher { TeacherName = "James White" }
        };
            context.Teachers.AddRange(teachers);

            // Zaman Dilimleri
            var timeSlots = new List<TimeSlot>
        {
            new TimeSlot { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(10, 45, 0), EndTime = new TimeSpan(12, 15, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(10, 45, 0), EndTime = new TimeSpan(12, 15, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(10, 45, 0), EndTime = new TimeSpan(12, 15, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(10, 45, 0), EndTime = new TimeSpan(12, 15, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
            new TimeSlot { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(10, 45, 0), EndTime = new TimeSpan(12, 15, 0) }
        };
            context.TimeSlots.AddRange(timeSlots);

            context.SaveChanges();
        }
    }
}
