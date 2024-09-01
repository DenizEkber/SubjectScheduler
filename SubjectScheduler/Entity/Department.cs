
namespace SubjectScheduler.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
