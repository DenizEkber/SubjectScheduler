using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Tablonun ismini ve Primary Key'i belirleme
            builder.ToTable("Teachers");
            builder.HasKey(t => t.TeacherId);

            // Öğretmen adının benzersiz olması
            builder.HasIndex(t => t.TeacherName).IsUnique();

            // İlişkiler
            builder.HasMany(t => t.Schedules)
                   .WithOne(s => s.Teacher)
                   .HasForeignKey(s => s.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Diğer yapılandırmalar...
        }
    }
}
