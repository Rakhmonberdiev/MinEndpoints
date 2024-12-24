using Microsoft.EntityFrameworkCore;
using MinEndpoints.Data;
using MinEndpoints.Data.Seed;

namespace MinEndpoints.Extensions
{
    public static class MigrationExtensions
    {
        public static async void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            db.Database.Migrate();
            await Seed.SeedUsers(db);
        }
    }
}
