using Domain.Entities.MedicalExaminationRequestAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.MedicalExaminationRequestAggregate
{
    public class MedicalExaminationRequestConfiguration : IEntityTypeConfiguration<MedicalExaminationRequest>
    {
        public void Configure(EntityTypeBuilder<MedicalExaminationRequest> builder)
        {
            builder.HasOne(me => me.Doctor)
                .WithMany(d => d.MedicalExaminationRequests)
                .HasForeignKey(me => me.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(me => me.Patiant)
                .WithMany(p => p.MedicalExaminationRequests)
                .HasForeignKey(me => me.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
