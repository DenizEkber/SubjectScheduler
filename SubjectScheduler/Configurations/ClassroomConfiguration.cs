using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            // Tablonun ismini ve Primary Key'i belirleme
            builder.ToTable("Classrooms");
            builder.HasKey(c => c.ClassroomId);

            // Sınıfın konumu benzersiz olmalı
            builder.HasIndex(c => c.Location).IsUnique();

            // İlişkiler
            builder.HasMany(c => c.Schedules)
                   .WithOne(s => s.Classroom)
                   .HasForeignKey(s => s.ClassroomId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Diğer yapılandırmalar...
        }
    }
}
