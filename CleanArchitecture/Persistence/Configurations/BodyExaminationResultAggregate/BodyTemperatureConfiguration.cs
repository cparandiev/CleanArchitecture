using Domain.Entities.BodyExaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyExaminationResultAggregate
{
    public class BodyTemperatureConfiguration : IEntityTypeConfiguration<BodyTemperatureExamination>
    {
        public void Configure(EntityTypeBuilder<BodyTemperatureExamination> builder)
        {
            builder.HasOne(b => b.Result)
                .WithOne(r => r.BodyTemperature)
                .HasForeignKey<BodyTemperatureExamination>(b => b.ResultId);
        }
    }
}
