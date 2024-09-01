using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Tablonun ismini ve Primary Key'i belirleme
            builder.ToTable("Departments");
            builder.HasKey(d => d.DepartmentId);

            // Bölüm adının benzersiz olması
            builder.HasIndex(d => d.DepartmentName).IsUnique();

            // İlişkiler
            builder.HasMany(d => d.Courses)
                   .WithOne(c => c.Department)
                   .HasForeignKey(c => c.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Diğer yapılandırmalar...
        }
    }
}
