using Domain.Entities.AdminAggregate;
using Domain.Entities.ClinicAggregate;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence.Helpers;

namespace Persistence
{
    public class Context : DbContext
    {
        private readonly DbContextOptions<Context> _options;
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            _options = options;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
