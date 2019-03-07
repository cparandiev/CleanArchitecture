using Domain.Entities.BodyExaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.BodyExaminationResultAggregate
{
    public class BodyExaminationResultTypeConfiguration : IEntityTypeConfiguration<BodyExaminationResultType>
    {
        public void Configure(EntityTypeBuilder<BodyExaminationResultType> builder)
        {
            builder.HasKey(rt => new { rt.BodyExaminationResultId, rt.BodyExaminationTypeId});

            builder.HasOne(rt => rt.Result)
                .WithMany(r => r.BodyExaminationResultTypes)
                .HasForeignKey(rt => rt.BodyExaminationResultId);

            builder.HasOne(rt => rt.Type)
                .WithMany(t => t.BodyExaminationResultTypes)
                .HasForeignKey(rt => rt.BodyExaminationTypeId);
        }
    }
}
