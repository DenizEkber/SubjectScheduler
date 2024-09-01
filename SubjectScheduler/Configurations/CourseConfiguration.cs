using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Tablonun ismini ve Primary Key'i belirleme
            builder.ToTable("Courses");
            builder.HasKey(c => c.CourseId);

            // İlişkiler
            builder.HasOne(c => c.Department)
                   .WithMany(d => d.Courses)
                   .HasForeignKey(c => c.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Diğer yapılandırmalar...
        }
    }
}
