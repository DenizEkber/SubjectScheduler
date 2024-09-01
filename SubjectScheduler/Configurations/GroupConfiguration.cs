using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.GroupId);

            builder.Property(g => g.GroupName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(g => g.CourseYear)
                   .IsRequired();

            // Grup ve Kurs arasındaki ilişkiyi belirle
            builder.HasMany(g => g.Courses)
                   .WithMany(c => c.Groups) // Course entity'sinde tanımlı olmalı
                   .UsingEntity(j => j.ToTable("GroupCourses")); // Ara tablo

            builder.HasMany(g => g.Schedules)
                   .WithOne(s => s.Group)
                   .HasForeignKey(s => s.GroupId);
        }
    }
}
