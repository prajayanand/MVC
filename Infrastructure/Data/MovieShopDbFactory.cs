using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Data
{
    public class MovieShopDbContextFactory : IDesignTimeDbContextFactory<MovieShopDbContext>
    {
        public MovieShopDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MovieShopDbContext>();
            var connectionString = configuration.GetConnectionString("MovieShopConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new MovieShopDbContext(optionsBuilder.Options);
        }
    }
}