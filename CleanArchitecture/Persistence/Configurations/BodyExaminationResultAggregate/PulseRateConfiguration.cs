using Domain.Entities.BodyExaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyExaminationResultAggregate
{
    public class PulseRateConfiguration : IEntityTypeConfiguration<PulseRateExamination>
    {
        public void Configure(EntityTypeBuilder<PulseRateExamination> builder)
        {
            builder.HasOne(b => b.Result)
                .WithOne(r => r.PulseRate)
                .HasForeignKey<PulseRateExamination>(b => b.ResultId);
        }
    }
}
