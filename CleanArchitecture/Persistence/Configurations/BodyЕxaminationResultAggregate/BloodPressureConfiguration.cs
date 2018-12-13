using Domain.Entities.BodyЕxaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyЕxaminationResultAggregate
{
    public class BloodPressureConfiguration : IEntityTypeConfiguration<BloodPressureExamination>
    {
        public void Configure(EntityTypeBuilder<BloodPressureExamination> builder)
        {
            builder.HasOne(b => b.Result)
                .WithOne(r => r.BloodPressure)
                .HasForeignKey<BloodPressureExamination>(b => b.ResultId);
        }
    }
}
