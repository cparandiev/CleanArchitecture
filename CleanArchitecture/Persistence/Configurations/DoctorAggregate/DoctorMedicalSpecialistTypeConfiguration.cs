using Domain.Entities.DoctorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.DoctorAggregate
{
    public class DoctorMedicalSpecialistTypeConfiguration : IEntityTypeConfiguration<DoctorMedicalSpecialistType>
    {
        public void Configure(EntityTypeBuilder<DoctorMedicalSpecialistType> builder)
        {
            builder.HasKey(dm => new { dm.DoctorId, dm.MedicalSpecialistTypeId});

            builder.HasOne(dm => dm.Doctor)
                .WithMany(d => d.DoctorMedicalSpecialistTypes)
                .HasForeignKey(dm => dm.DoctorId);

            builder.HasOne(dm => dm.Type)
                .WithMany(m => m.DoctorMedicalSpecialistTypes)
                .HasForeignKey(dm => dm.MedicalSpecialistTypeId);
        }
    }
}
