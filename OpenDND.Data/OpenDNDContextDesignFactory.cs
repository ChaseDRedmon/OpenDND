using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OpenDND.Data
{
    public class OpenDNDContextDesignFactory: IDesignTimeDbContextFactory<OpenDNDContext>
    {
        /// <summary>
        /// Scaffold a fake database constructor for EF core migrations
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public OpenDNDContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OpenDNDContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Capstone;Trusted_Connection=True;");
            return new OpenDNDContext(optionsBuilder.Options);
        }
    }
}