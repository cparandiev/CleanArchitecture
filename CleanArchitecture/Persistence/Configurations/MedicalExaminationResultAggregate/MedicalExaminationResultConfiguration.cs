using Domain.Entities.MedicalExaminationResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.MedicalExaminationResultAggregate
{
    public class MedicalExaminationResultConfiguration : IEntityTypeConfiguration<MedicalExaminationResult>
    {
        public void Configure(EntityTypeBuilder<MedicalExaminationResult> builder)
        {
            builder.HasOne(m => m.Request)
                .WithOne(r => r.Result)
                .HasForeignKey<MedicalExaminationResult>(m => m.RequestId);
        }
    }
}
