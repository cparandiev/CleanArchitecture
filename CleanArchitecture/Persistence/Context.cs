using Domain.Entities.MedicalExaminationRequestAggregate;
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
