using Domain.Entities.BodyЕxaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyЕxaminationResultAggregate
{
    public class BodyЕxaminationResultTypeConfiguration : IEntityTypeConfiguration<BodyЕxaminationResultType>
    {
        public void Configure(EntityTypeBuilder<BodyЕxaminationResultType> builder)
        {
            builder.HasKey(rt => new { rt.BodyЕxaminationResultId, rt.BodyЕxaminationTypeId});

            builder.HasOne(rt => rt.Result)
                .WithMany(r => r.BodyЕxaminationResultTypes)
                .HasForeignKey(rt => rt.BodyЕxaminationResultId);

            builder.HasOne(rt => rt.Type)
                .WithMany(t => t.BodyЕxaminationResultTypes)
                .HasForeignKey(rt => rt.BodyЕxaminationTypeId);
        }
    }
}
