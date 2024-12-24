using Microsoft.EntityFrameworkCore;
using MinEndpoints.Abstractions;
using MinEndpoints.Data;


namespace MinEndpoints.Endpoints
{
    public class Get : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("get", async (IAppDbContext db, CancellationToken cancellationToken) =>
            {
                var users = await db.Users.ToListAsync(cancellationToken);

                if(users != null) return Results.Ok(users);

                return Results.NotFound();
            });
        }
    }
}
