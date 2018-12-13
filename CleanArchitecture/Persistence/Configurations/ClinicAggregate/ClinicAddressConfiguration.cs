using Domain.Entities.ClinicAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.ClinicAggregate
{
    public class ClinicAddressConfiguration : IEntityTypeConfiguration<ClinicAddress>
    {
        public void Configure(EntityTypeBuilder<ClinicAddress> builder)
        {
            builder.HasKey(ca => ca.ClinicId);

            builder.HasOne(ca => ca.Clinic)
                .WithOne(c => c.Address)
                .HasForeignKey<ClinicAddress>(ca => ca.ClinicId);
        }
    }
}
