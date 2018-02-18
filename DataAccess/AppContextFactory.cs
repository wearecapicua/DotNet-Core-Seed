using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccess
{
    public class AppContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(
                "Server=FERRAN\\SQLEXPRESS2012;Database=NetCoreSeed;Trusted_Connection=True;ConnectRetryCount=0");

            return new ApplicationDbContext(builder.Options);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(
              "Server=FERRAN\\SQLEXPRESS2012;Database=NetCoreSeed;Trusted_Connection=True;ConnectRetryCount=0");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
