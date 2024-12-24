using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MinEndpoints.Data;

namespace MinEndpoints.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(connectionString, npgsqlOpt => npgsqlOpt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "public"));
            });
            services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());
            return services;
        }

    }
}
