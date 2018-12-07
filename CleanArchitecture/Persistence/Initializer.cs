using Domain.Entities;
using Domain.Enums;
using System.Linq;

namespace Persistence
{
    public class Initializer
    {
        public static void Initialize(Context context)
        {
            var initializer = new Initializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(Context context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Db has been seeded
            }

            SeedUsers(context);
        }

        public void SeedUsers(Context context)
        {
            var newUsers = new[]
            {
                new User() {Role = Role.Patient, Username = "John" },
                new User() {Role = Role.Patient, Username = "Tony" },
                new User() {Role = Role.Patient, Username = "Hank" }
            };

            context.Users.AddRange(newUsers);

            context.SaveChanges();
        }
    }
}
