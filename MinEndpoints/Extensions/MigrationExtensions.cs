using Microsoft.EntityFrameworkCore;
using MinEndpoints.Data;

namespace MinEndpoints.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            db.Database.Migrate();
        }
    }
}
