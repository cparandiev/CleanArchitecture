using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Persistence.Helpers
{
    public static class EFExtensions
    {
        public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var configurations = assembly.DefinedTypes.Where(t =>
                 t.ImplementedInterfaces.Any(i =>
                    i.IsGenericType &&
                    i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
                           StringComparison.InvariantCultureIgnoreCase)
                  ) &&
                  t.IsClass &&
                  !t.IsAbstract &&
                  !t.IsNested)
                  .ToList();

            foreach (var configuration in configurations)
            {
                var entityType = configuration
                    .GetInterface(typeof(IEntityTypeConfiguration<>).Name)
                    .GenericTypeArguments.SingleOrDefault(t => t.IsClass);

                var applyConfigMethod = typeof(ModelBuilder)
                    .GetMethods()
                    .First(m =>
                        m.Name == "ApplyConfiguration" &&
                        m.GetParameters()?.First()?.ParameterType?.Name == typeof(IEntityTypeConfiguration<>).Name
                    );

                //var applyConfigMethod = modelBuilder.GetType().GetMethod("ApplyConfiguration", new Type[] { typeof(IEntityTypeConfiguration<>).MakeGenericType(entityType) });

                var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);

                applyConfigGenericMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(configuration) });
            }
        }
    }
}
