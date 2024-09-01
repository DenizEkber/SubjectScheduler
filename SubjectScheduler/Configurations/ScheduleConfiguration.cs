using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            // Tablonun ismini ve Primary Key'i belirleme
            builder.ToTable("Schedules");
            builder.HasKey(s => s.ScheduleId);

            // İlişkiler
            builder.HasOne(s => s.Course)
                   .WithMany(c => c.Schedules)
                   .HasForeignKey(s => s.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Teacher)
                   .WithMany(t => t.Schedules)
                   .HasForeignKey(s => s.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Classroom)
                   .WithMany(c => c.Schedules)
                   .HasForeignKey(s => s.ClassroomId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.TimeSlot)
                   .WithMany(ts => ts.Schedules)
                   .HasForeignKey(s => s.TimeSlotId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Group)
                   .WithMany(g => g.Schedules)
                   .HasForeignKey(s => s.GroupId);

            // Diğer yapılandırmalar...
        }
    }
}
