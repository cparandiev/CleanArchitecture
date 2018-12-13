using Domain.Entities.DoctorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.DoctorAggregate
{
    public class DoctorWorkingTimeConfiguration : IEntityTypeConfiguration<DoctorWorkingTime>
    {
        public void Configure(EntityTypeBuilder<DoctorWorkingTime> builder)
        {
            builder.HasOne(dw => dw.Doctor)
                .WithMany(d => d.WorkingTimes)
                .HasForeignKey(dw => dw.DoctorId);
        }
    }
}
