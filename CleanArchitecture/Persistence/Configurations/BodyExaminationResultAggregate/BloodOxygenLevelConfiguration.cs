using Domain.Entities.BodyExaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyExaminationResultAggregate
{
    public class BloodOxygenLevelConfiguration : IEntityTypeConfiguration<BloodOxygenLevelExamination>
    {
        public void Configure(EntityTypeBuilder<BloodOxygenLevelExamination> builder)
        {
            builder.HasOne(b => b.Result)
                .WithOne(r => r.BloodOxygenLevel)
                .HasForeignKey<BloodOxygenLevelExamination>(b => b.ResultId);
        }
    }
}
