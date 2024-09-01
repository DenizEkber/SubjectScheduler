using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Configurations;
using SubjectScheduler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectScheduler.Context
{
    public class UniversityContext : DbContext
    {
        private string connectionString = "Server=USER\\SQLEXPRESS;Database=SubjectScheduler;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Department> Departments { get; set; } // Department DbSet tanımlaması


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSlotConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration()); // DepartmentConfiguration eklendi

            base.OnModelCreating(modelBuilder);
        }
    }
}
