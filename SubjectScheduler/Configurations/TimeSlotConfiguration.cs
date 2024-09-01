using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubjectScheduler.Entity;

namespace SubjectScheduler.Configurations
{
    public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> builder)
        {
            // Tablonun ismini ve Primary Key'i belirleme
            builder.ToTable("TimeSlots");
            builder.HasKey(ts => ts.TimeSlotId);

            // Aynı gün ve saat çakışmasını engelleme
            builder.HasIndex(ts => new { ts.DayOfWeek, ts.StartTime, ts.EndTime })
                   .IsUnique();

            // İlişkiler
            builder.HasMany(ts => ts.Schedules)
                   .WithOne(s => s.TimeSlot)
                   .HasForeignKey(s => s.TimeSlotId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Diğer yapılandırmalar...
        }
    }
}
