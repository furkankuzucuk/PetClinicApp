using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AuthAPI.Data
{
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            // 🔽 appsettings.json dosyasını oku
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // AuthAPI projesinin kökü
                .AddJsonFile("appsettings.json")
                .Build();

            // 🔽 Connection string çek
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<AuthDbContext>();
            builder.UseSqlServer(connectionString);

            return new AuthDbContext(builder.Options);
        }
    }
}
