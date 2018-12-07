using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
