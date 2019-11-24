using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OpenDND.Data.Models.App;
using OpenDND.Data.Models.DND;
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
        
        // DND Database Tables
        public DbSet<BackgroundRootObject> Backgrounds { get; set; }
        
        public DbSet<Character> Characters { get; set; }
        
        public DbSet<ClassRootObject> Classes { get; set; }
        
        public DbSet<ConditionRootObject> Conditions { get; set; }
        
        public DbSet<FeatsRootObject> Feats { get; set; }
        
        public DbSet<RootItems> Items { get; set; }
        
        public DbSet<RootMonsters> RootMonsters { get; set; }
        
        public DbSet<PlanesResult> Planes { get; set; }
        
        public DbSet<RacesRootObject> Races { get; set; }
        
        public DbSet<SectionsRootObject> Sections { get; set; }
        
        public DbSet<SpellsRootObject> Spells { get; set; }
        
        public DbSet<WeaponsRootObject> Weapons { get; set; }
        
        
        // Application Tables
        public DbSet<SpellsRootObject> Roles { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<BehaviourConfiguration> BehaviourConfigurations { get; set; }
        
        // Web Tables
        
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