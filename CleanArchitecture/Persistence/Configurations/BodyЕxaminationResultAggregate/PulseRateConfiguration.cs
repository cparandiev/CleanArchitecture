using Domain.Entities.BodyЕxaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyЕxaminationResultAggregate
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
