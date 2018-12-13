using Domain.Entities.UserAggregate;
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
            var newRoles = new[]
            {
                new Role(){Value = Domain.Enums.Role.Admin},
                new Role(){Value = Domain.Enums.Role.Doctor},
                new Role(){Value = Domain.Enums.Role.Patient},
            };

            var newUsers = new[]
            {
                new User() {Username = "John", UserRoles = new[] { new UserRole() { Role = newRoles[0] }, new UserRole() { Role = newRoles[1]}, new UserRole() { Role = newRoles[2] }}},
                new User() {Username = "Tony", UserRoles = new[] { new UserRole() { Role = newRoles[0] }, new UserRole() { Role = newRoles[1]}}},
                new User() {Username = "Hank", UserRoles = new[] { new UserRole() { Role = newRoles[0] }}}
            };

            context.Users.AddRange(newUsers);

            context.SaveChanges();
        }
    }
}
