using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OpenDND.Data.Utilities;

namespace OpenDND.Data
{
    public class OpenDNDContext : DbContext
    {
        public OpenDNDContext(DbContextOptions<OpenDNDContext> options) : base(options)
        {
        }

        public OpenDNDContext()
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var onModelCreatingMethods = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(x => x.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(x => !(x.GetCustomAttribute<OnModelCreatingAttribute>() is null));

            var relationships = modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());

            foreach (var method in onModelCreatingMethods)
            {
                method.Invoke(null, new[] {modelBuilder});
            }
            
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}